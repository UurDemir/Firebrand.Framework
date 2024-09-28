using Firebrand.Exception;

namespace Firebrand.Redis.Exception;

/// <summary>
/// The exception that is thrown when no Redis endpoints are specified.
/// </summary>
public class RedisEndPointNotFoundException : FirebrandException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RedisEndPointNotFoundException"/> class.
    /// </summary>
    public RedisEndPointNotFoundException() : base("RedisEndPointNotFound", "No endpoints specified")
    {
    }
}
