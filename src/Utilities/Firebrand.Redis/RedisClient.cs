using Firebrand.Redis.Configuration;
using Firebrand.Redis.Exception;

using StackExchange.Redis;

using System.Collections.Concurrent;
using System.Net;

namespace Firebrand.Redis;

/// <summary>
/// Represents a Redis client.
/// </summary>
public class RedisClient
{
    private readonly string clientName;
    private readonly RedisConnectionConfiguration configuration;
    private ConnectionMultiplexer? connection;
    private ConcurrentDictionary<int, Lazy<IDatabase>>? databases;

    internal RedisClient(string clientName, RedisConnectionConfiguration configuration)
    {
        this.clientName = clientName;
        this.configuration = configuration;

        if (configuration.EndPoints is null or { Length: 0 })
            throw new RedisEndPointNotFoundException();
    }

    /// <summary>
    /// Establishes a connection to the Redis server asynchronously.
    /// </summary>
    internal async Task ConnectAsync()
    {
        var config = new ConfigurationOptions
        {
            AbortOnConnectFail = configuration.AbortOnConnectFail,
            ConnectTimeout = configuration.ConnectTimeout,
            AllowAdmin = configuration.AllowAdmin,
            AsyncTimeout = configuration.AsyncTimeout,
            ConnectRetry = configuration.ConnectRetry,
            DefaultDatabase = configuration.DefaultDatabase,
            KeepAlive = configuration.KeepAlive,
            Password = configuration.Password,
            Ssl = configuration.Ssl,
            SslHost = configuration.SslHost,
            SyncTimeout = configuration.SyncTimeout,
            CheckCertificateRevocation = configuration.CheckCertificateRevocation,
            ClientName = configuration.ClientName ?? clientName,
        };

        foreach (var endpoint in configuration.EndPoints!)
        {
            if (endpoint.Host is not null)
            {
                if (IPAddress.TryParse(endpoint.Host, out var address))
                    config.EndPoints.Add(address, endpoint.Port);
                else
                    config.EndPoints.Add(endpoint.Host, endpoint.Port);
            }
            else if (endpoint.HostPort is not null)
            {
                config.EndPoints.Add(endpoint.HostPort);
            }
        }

        connection = await ConnectionMultiplexer.ConnectAsync(config);

        PrepareDatabases();
    }

    /// <summary>
    /// Sets a string value in Redis asynchronously using the default database.
    /// </summary>
    /// <param name="key">The key to set.</param>
    /// <param name="value">The value to set.</param>
    public async Task<bool> SetAsync(string key, string value)
    {
        return await SetAsync(key, value, configuration.DefaultDatabase ?? -1);
    }

    /// <summary>
    /// Sets a string value in Redis asynchronously using the specified database.
    /// </summary>
    /// <param name="key">The key to set.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="db">The database to use.</param>
    public async Task<bool> SetAsync(string key, string value, int db)
    {
        var database = connection!.GetDatabase(db);
        return await database.StringSetAsync(key, value);
    }

    /// <summary>
    /// Gets a string value from Redis asynchronously using the default database.
    /// </summary>
    /// <param name="key">The key to get.</param>
    public async Task<string?> GetAsync(string key)
    {
        return await GetAsync(key, configuration.DefaultDatabase ?? -1);
    }

    /// <summary>
    /// Gets a string value from Redis asynchronously using the specified database.
    /// </summary>
    /// <param name="key">The key to get.</param>
    /// <param name="db">The database to use.</param>
		public async Task<string?> GetAsync(string key, int db)
    {
        var database = databases![db].Value;
        return await database.StringGetAsync(key);
    }

    private void PrepareDatabases()
    {
        databases = new ConcurrentDictionary<int, Lazy<IDatabase>>(configuration.DatabaseCount, configuration.DatabaseCount);

        for (int i = 0; i < configuration.DatabaseCount; i++)
        {
            IDatabase databaseFactory()
            {
                var database = connection!.GetDatabase(i);
                return database;
            }

            var lazyDatabase = new Lazy<IDatabase>(databaseFactory, true);

            databases.TryAdd(i, lazyDatabase);
        }
    }
}