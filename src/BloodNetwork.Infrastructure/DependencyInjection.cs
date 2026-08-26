using BloodNetwork.Application.Interfaces;
using BloodNetwork.Application.Services;
using BloodNetwork.Domain.Interfaces;
using BloodNetwork.Infrastructure.Authentication;
using BloodNetwork.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BloodNetwork.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddScoped<AuthService>();
        services.AddScoped<DonorService>();
        services.AddScoped<BloodRequestService>();

        return services;
    }
}
