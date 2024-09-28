using Firebrand.Redis.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Firebrand.Redis;

/// <summary>
/// Extension methods for adding Redis support to the dependency injection container.
/// </summary>
public static class RedisDependencyInjectionExtension
{
    /// <summary>
    /// Adds Redis support to the specified service collection using the specified configuration.
    /// </summary>
    /// <param name="services">The service collection to add Redis support to.</param>
    /// <param name="configuration">The configuration for Redis.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddFirebrandRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RedisConfiguration>(configuration.GetSection("FBRedis"));
        services.AddSingleton<IRedisClientFactory, RedisClientFactory>();

        return services;
    }
}
