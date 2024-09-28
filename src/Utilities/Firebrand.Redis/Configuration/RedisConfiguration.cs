namespace Firebrand.Redis.Configuration;

/// <summary>
/// Represents the configuration for one or more Redis connections.
/// </summary>
public class RedisConfiguration
{
    /// <summary>
    /// Gets or sets a dictionary of Redis connection names and their corresponding configuration.
    /// </summary>
    public IDictionary<string, RedisConnectionConfiguration>? Connections { get; set; }
}
