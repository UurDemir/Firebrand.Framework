using Firebrand.Exception;

namespace Firebrand.Redis.Exception;

/// <summary>
/// The exception that is thrown when no Redis configurations are specified.
/// </summary>
public class RedisConfigurationNotFoundException : FirebrandException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RedisConfigurationNotFoundException"/> class.
    /// </summary>
    public RedisConfigurationNotFoundException() : base("RedisConfigurationNotFound", "No Redis configurations specified")
    {
    }
}
