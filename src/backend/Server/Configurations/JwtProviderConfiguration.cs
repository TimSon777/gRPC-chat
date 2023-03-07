using Server.Abstractions;
using Server.Services;

namespace Server.Configurations;

public static class JwtProviderConfiguration
{
    public static IServiceCollection AddJwtProvider(this IServiceCollection services)
    {
        services.AddTransient<IJwtProvider, JwtProvider>();
        return services;
    }
}