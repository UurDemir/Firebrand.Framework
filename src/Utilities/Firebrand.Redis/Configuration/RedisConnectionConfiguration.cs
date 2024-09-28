namespace Firebrand.Redis.Configuration;

/// <summary>
/// Represents the configuration for a Redis connection.
/// </summary>
public class RedisConnectionConfiguration
{
    /// <summary>
    /// Gets or sets the number of Redis databases to use. The default value is 16.
    /// </summary>
    public int DatabaseCount { get; set; } = 16;

    /// <summary>
    /// Gets or sets a value indicating whether to abort the connection if the connection attempt fails. The default value is false.
    /// </summary>
    public bool AbortOnConnectFail { get; set; }

    /// <summary>
    /// Gets or sets the time in milliseconds to wait for a connection attempt to complete. The default value is 5000 (5 seconds).
    /// </summary>
    public int ConnectTimeout { get; set; } = 5 * 1000;

    /// <summary>
    /// Gets or sets the time in milliseconds to wait for a synchronous Redis command to complete. The default value is 5000 (5 seconds).
    /// </summary>
    public int SyncTimeout { get; set; } = 5 * 1000;

    /// <summary>
    /// Gets or sets the time in milliseconds to wait for an asynchronous Redis command to complete. The default value is 5000 (5 seconds).
    /// </summary>
    public int AsyncTimeout { get; set; } = 5 * 1000;

    /// <summary>
    /// Gets or sets a value indicating whether to allow administrative commands on the Redis server. The default value is false.
    /// </summary>
    public bool AllowAdmin { get; set; }

    /// <summary>
    /// Gets or sets the number of times to retry the connection if the connection attempt fails. The default value is 3.
    /// </summary>
    public int ConnectRetry { get; set; } = 3;

    /// <summary>
    /// Gets or sets the default Redis database to use. If not set, the default value is null.
    /// </summary>
    public int? DefaultDatabase { get; set; }

    /// <summary>
    /// Gets or sets the keep-alive time in seconds for the Redis connection. The default value is -1, which disables keep-alive.
    /// </summary>
    public int KeepAlive { get; set; } = -1;

    /// <summary>
    /// Gets or sets the password to use for the Redis connection. If not set, the default value is null.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use SSL/TLS encryption for the Redis connection. The default value is false.
    /// </summary>
    public bool Ssl { get; set; }

    /// <summary>
    /// Gets or sets the hostname or IP address of the Redis server to use for SSL/TLS encryption. If not set, the default value is null.
    /// </summary>
    public string? SslHost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to check the certificate revocation status for SSL/TLS connections. The default value is false.
    /// </summary>
    public bool CheckCertificateRevocation { get; set; }

    /// <summary>
    /// Gets or sets the name of the Redis client to use for the connection. If not set, the default value is null.
    /// </summary>
    public string? ClientName { get; set; }

    /// <summary>
    /// Gets or sets the endpoints of the Redis server to connect to.
    /// </summary>
    public RedisEndPoint[]? EndPoints { get; set; }
}