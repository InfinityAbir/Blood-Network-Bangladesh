using System.Text;
using System.Threading.RateLimiting;
using BloodNetwork.Api.Middleware;
using BloodNetwork.Application.Configuration;
using BloodNetwork.Infrastructure;
using BloodNetwork.Infrastructure.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateEmptyBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(8080);
});

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

if (builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddDbContext<BloodNetworkDbContext>(options =>
        options.UseInMemoryDatabase("BloodNetworkTestDb"));
}
else
{
    builder.Services.AddDbContext<BloodNetworkDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddValidatorsFromAssembly(typeof(BloodNetwork.Application.DTOs.RegisterRequest).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtSecret = builder.Configuration["Jwt:Secret"]!;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        var origins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
            ?? new[] { "http://localhost:4200" };
        policy.WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter("auth", lo =>
    {
        lo.PermitLimit = 10;
        lo.Window = TimeSpan.FromMinutes(1);
        lo.QueueLimit = 0;
    });

    options.AddFixedWindowLimiter("api", lo =>
    {
        lo.PermitLimit = 60;
        lo.Window = TimeSpan.FromMinutes(1);
        lo.QueueLimit = 0;
    });

    options.AddFixedWindowLimiter("search", lo =>
    {
        lo.PermitLimit = 30;
        lo.Window = TimeSpan.FromMinutes(1);
        lo.QueueLimit = 0;
    });

    options.OnRejected = async (ctx, ct) =>
    {
        ctx.HttpContext.Response.ContentType = "application/json";
        var response = new
        {
            success = false,
            message = "Rate limit exceeded. Please try again later.",
            retryAfter = ctx.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter)
                ? (int)retryAfter.TotalSeconds : 60
        };
        await ctx.HttpContext.Response.WriteAsJsonAsync(response, ct);
    };
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.Configure<GroqOptions>(builder.Configuration.GetSection(GroqOptions.SectionName));

builder.Services.AddHealthChecks()
    .AddDbContextCheck<BloodNetworkDbContext>();

var app = builder.Build();

if (!app.Environment.IsEnvironment("Testing"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
    await db.Database.MigrateAsync();

    // --- Seed default admin (idempotent) ---
    var adminPhone = app.Configuration["Admin:Phone"]
        ?? Environment.GetEnvironmentVariable("ADMIN_PHONE");
    var adminPassword = app.Configuration["Admin:Password"]
        ?? Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
    var adminEmail = app.Configuration["Admin:Email"]
        ?? Environment.GetEnvironmentVariable("ADMIN_EMAIL")
        ?? "admin@bloodnetworkbd.com";

    if (string.IsNullOrWhiteSpace(adminPhone) || string.IsNullOrWhiteSpace(adminPassword))
    {
        Log.Warning("Admin credentials not configured. Set ADMIN_PHONE and ADMIN_PASSWORD environment variables. Skipping admin seed.");
    }

    if (!string.IsNullOrWhiteSpace(adminPhone) && !string.IsNullOrWhiteSpace(adminPassword))
    {
        var adminExists = await db.Users.AnyAsync(u => u.PhoneNumber == adminPhone);
        if (!adminExists)
        {
            var hasher = new BloodNetwork.Infrastructure.Authentication.PasswordHasher();
            var admin = new BloodNetwork.Domain.Entities.User
            {
                Id = Guid.NewGuid(),
                FirstName = "System",
                LastName = "Admin",
                PhoneNumber = adminPhone,
                Email = adminEmail,
                PasswordHash = hasher.HashPassword(adminPassword),
                Role = BloodNetwork.Domain.Enums.UserRole.Admin,
                IsActive = true,
                IsPhoneVerified = true,
                MustChangePassword = true,
                CreatedAt = DateTime.UtcNow
            };
            db.Users.Add(admin);
            await db.SaveChangesAsync();
            Log.Information("Seeded default admin {Phone}", adminPhone);
        }
        else
        {
            // Ensure existing default admin is forced to change password on first login
            var existing = await db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == adminPhone);
            if (existing != null && !existing.MustChangePassword && existing.LastLoginAt == null)
            {
                existing.MustChangePassword = true;
                await db.SaveChangesAsync();
                Log.Information("Updated existing admin {Phone} to require password change", adminPhone);
            }
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blood Network Bangladesh API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireRateLimiting("api");
app.MapHealthChecks("/health");
app.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});

try
{
    Log.Information("Starting Blood Network Bangladesh API");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
