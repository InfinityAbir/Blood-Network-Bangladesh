using System.Text;
using System.Threading.RateLimiting;
using BloodNetwork.Api.Hubs;
using BloodNetwork.Api.Middleware;
using BloodNetwork.Api.Services;
using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Infrastructure;
using BloodNetwork.Infrastructure.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(BloodNetwork.Application.DTOs.RegisterRequest).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtSecret = builder.Configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret missing");
if (Encoding.UTF8.GetByteCount(jwtSecret) < 32) throw new InvalidOperationException("Jwt:Secret must be >=32 bytes");
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

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notifications"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSignalR();

builder.Services.AddScoped<INotificationBroadcaster, SignalRNotificationBroadcaster>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        var origins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
            ?? new[] { "http://localhost:4200" };
        policy.WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Partition key for rate limiting: authenticated requests are keyed per-user (from the
// JWT), anonymous ones per client IP. Using a bare AddFixedWindowLimiter would create a
// single counter shared by every client hitting the API - one caller could exhaust it
// and lock everyone else out of login/register/refresh or the whole authenticated API.
static string RateLimitPartitionKey(HttpContext httpContext)
{
    var userId = httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
    if (!string.IsNullOrEmpty(userId)) return $"user:{userId}";
    return $"ip:{httpContext.Connection.RemoteIpAddress}";
}

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddPolicy("auth", httpContext => RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: RateLimitPartitionKey(httpContext),
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 0,
        }));

    options.AddPolicy("api", httpContext => RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: RateLimitPartitionKey(httpContext),
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 60,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 0,
        }));

    options.AddPolicy("search", httpContext => RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: RateLimitPartitionKey(httpContext),
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 30,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 0,
        }));

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
    .AddDbContextCheck<BloodNetworkDbContext>("db", tags: new[] { "ready" })
    .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new[] { "ready" });

var app = builder.Build();

if (!app.Environment.IsEnvironment("Testing"))
{
    try
    {
        using var migrationScope = app.Services.CreateScope();
        var migrationDb = migrationScope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        await migrationDb.Database.MigrateAsync();
        Log.Information("Database migration completed");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Database migration failed. App will start but may not function correctly.");
    }

    // --- Seed default admin (idempotent) ---
    try
    {
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

        using var seedScope = app.Services.CreateScope();
        var db = seedScope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();

        if (!string.IsNullOrWhiteSpace(adminPhone) && !string.IsNullOrWhiteSpace(adminPassword))
        {
            var adminExists = await db.Users.AnyAsync(u => u.Role == BloodNetwork.Domain.Enums.UserRole.Admin);
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
                var existing = await db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == adminPhone);
                if (existing != null)
                {
                    var hasher = new BloodNetwork.Infrastructure.Authentication.PasswordHasher();
                    bool needsUpdate = false;
                    // If stored hash still matches default env password, force change (covers post-reset case)
                    if (!existing.MustChangePassword && hasher.VerifyPassword(adminPassword, existing.PasswordHash))
                    {
                        existing.MustChangePassword = true;
                        needsUpdate = true;
                        Log.Information("Forced admin {Phone} to mustChangePassword (still default password)", adminPhone);
                    }
                    // Only re-hash before first login (prevents overwriting user-changed password)
                    if (existing.MustChangePassword && existing.LastLoginAt == null && !hasher.VerifyPassword(adminPassword, existing.PasswordHash))
                    {
                        existing.PasswordHash = hasher.HashPassword(adminPassword);
                        existing.Email = adminEmail;
                        needsUpdate = true;
                        Log.Information("Updated admin {Phone} password hash to match env (pre-first-login)", adminPhone);
                    }
                    if (!existing.MustChangePassword && existing.LastLoginAt == null)
                    {
                        existing.MustChangePassword = true;
                        needsUpdate = true;
                        Log.Information("Updated existing admin {Phone} to require password change", adminPhone);
                    }
                    if (needsUpdate) await db.SaveChangesAsync();
                }
            }
        }
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Admin seed failed. App will continue without admin account.");
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

// ForwardedHeaders must be first middleware to correctly capture client IP/scheme behind proxies
var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownProxies.Clear();
#pragma warning disable ASPDEPR005
forwardedHeadersOptions.KnownNetworks.Clear();
#pragma warning restore ASPDEPR005
forwardedHeadersOptions.KnownIPNetworks.Clear();
app.UseForwardedHeaders(forwardedHeadersOptions);
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseResponseCaching();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireRateLimiting("api");
app.MapHub<NotificationHub>("/hubs/notifications");
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
