namespace Firebrand.Security.Cryptography;

/// <summary>
/// Interface for a hash strategy that computes hash values for byte arrays and byte arrays with salts.
/// </summary>
public interface IHashStrategy : IDisposable
{
    /// <summary>
    /// Computes the hash of the specified byte array.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <returns>The computed hash.</returns>
    byte[] Hash(byte[] input);

    /// <summary>
    /// Computes the hash of the specified byte array using the specified salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <param name="salt">The salt to use for hashing the byte array.</param>
    /// <returns>The computed hash.</returns>
    byte[] Hash(byte[] input, byte[] salt);

    /// <summary>
    /// Asynchronously computes the hash of the specified byte array.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the computed hash.</returns>
    Task<byte[]> HashAsync(byte[] input);

    /// <summary>
    /// Asynchronously computes the hash of the specified byte array using the specified salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <param name="salt">The salt to use for hashing the byte array.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the computed hash.</returns>
    Task<byte[]> HashAsync(byte[] input, byte[] salt);
}
