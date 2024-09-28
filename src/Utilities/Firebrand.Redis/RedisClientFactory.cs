using Firebrand.Redis.Configuration;
using Firebrand.Redis.Exception;

using Microsoft.Extensions.Options;

using System.Collections.Concurrent;

namespace Firebrand.Redis;

/// <summary>
/// A factory that creates Redis clients based on the specified configuration.
/// </summary>
public class RedisClientFactory : IRedisClientFactory
{
    private readonly ConcurrentDictionary<string, Lazy<Task<RedisClient>>> clients;

    /// <summary>
    /// Initializes a new instance of the <see cref="RedisClientFactory"/> class using the specified configuration.
    /// </summary>
    /// <param name="configurationOption">The Redis configuration.</param>
    public RedisClientFactory(IOptions<RedisConfiguration> configurationOption)
    {
        if (configurationOption.Value is null || configurationOption.Value.Connections is null or { Count: 0 })
            throw new RedisConfigurationNotFoundException();

        RedisConfiguration configuration = configurationOption.Value;

        clients = new ConcurrentDictionary<string, Lazy<Task<RedisClient>>>(configuration.Connections.Count, configuration.Connections.Count);

        foreach (var connection in configuration.Connections)
        {
            var lazyClient = new Lazy<Task<RedisClient>>(async () =>
            {
                var redisClient = new RedisClient(connection.Key, connection.Value);

                await redisClient.ConnectAsync();

                return redisClient;
            }, true);

            clients.TryAdd(connection.Key, lazyClient);
        }
    }

    /// <inheritdoc/>
    public async Task<RedisClient> CreateClientAsync() => await CreateClientAsync("Default");

    /// <inheritdoc/>
    public async Task<RedisClient> CreateClientAsync(string clientName)
    {
        var client = await clients[clientName].Value.ConfigureAwait(false);
        return client;
    }

    /// <inheritdoc/>
    public RedisClient CreateClient() => CreateClient("Default");

    /// <inheritdoc/>
    public RedisClient CreateClient(string clientName)
    {
        var client = clients[clientName].Value.ConfigureAwait(false).GetAwaiter().GetResult();
        return client;
    }
}
