using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Application.Services;
using BloodNetwork.Domain.Interfaces;
using BloodNetwork.Infrastructure.Authentication;
using BloodNetwork.Infrastructure.Data;
using BloodNetwork.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodNetwork.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<BloodNetwork.Domain.Entities.RefreshToken>>(sp =>
        {
            var context = sp.GetRequiredService<BloodNetworkDbContext>();
            return new Repository<BloodNetwork.Domain.Entities.RefreshToken>(context);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IMapService, HaversineMapService>();

        services.AddScoped<AuthService>();
        services.AddScoped<DonorService>();
        services.AddScoped<BloodRequestService>();
        services.AddScoped<IMatchingService, MatchingService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IDonorEngagementService, DonorEngagementService>();
        services.AddScoped<IMatchEnhancementService, MatchEnhancementService>();
        services.AddScoped<IEligibilityService, EligibilityService>();
        services.AddScoped<IDeveloperInfoService, DeveloperInfoService>();

        services.Configure<MatchScoreWeightsOptions>(
            configuration.GetSection("AppSettings:MatchScoreWeights"));

        services.AddHttpClient<IAiChatService, GroqChatService>(c => c.Timeout = TimeSpan.FromSeconds(30));

        return services;
    }
}
