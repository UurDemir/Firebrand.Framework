namespace Firebrand.Redis;

/// <summary>
/// Represents a factory that creates Redis clients.
/// </summary>
public interface IRedisClientFactory
{
    /// <summary>
    /// Creates a new Redis client using the default client name.
    /// </summary>
    /// <returns>A Redis client.</returns>
    RedisClient CreateClient();

    /// <summary>
    /// Creates a new Redis client using the specified client name.
    /// </summary>
    /// <param name="clientName">The name of the Redis client to create.</param>
    /// <returns>A Redis client.</returns>
    RedisClient CreateClient(string clientName);

    /// <summary>
    /// Asynchronously creates a new Redis client using the default client name.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a Redis client.</returns>
    Task<RedisClient> CreateClientAsync();

    /// <summary>
    /// Asynchronously creates a new Redis client using the specified client name.
    /// </summary>
    /// <param name="clientName">The name of the Redis client to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a Redis client.</returns>
    Task<RedisClient> CreateClientAsync(string clientName);
}
