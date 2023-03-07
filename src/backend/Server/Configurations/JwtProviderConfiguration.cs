using Server.Abstractions;
using Server.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class JwtProviderConfiguration
{
    public static IServiceCollection AddJwtProvider(this IServiceCollection services)
    {
        services.AddTransient<IJwtProvider, JwtProvider>();
        return services;
    }
}