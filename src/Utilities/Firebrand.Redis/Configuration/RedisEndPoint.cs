namespace Firebrand.Redis.Configuration;

/// <summary>
/// Represents a Redis endpoint.
/// </summary>
public class RedisEndPoint
{
    /// <summary>
    /// Gets or sets the hostname or IP address of the Redis server.
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// Gets or sets the port number to use for the Redis server. The default value is 6379.
    /// </summary>
    public int Port { get; set; } = 6379;

    /// <summary>
    /// Gets or sets the hostname and port number of the Redis server in the format "host:port".
    /// </summary>
    public string? HostPort { get; set; }
}
