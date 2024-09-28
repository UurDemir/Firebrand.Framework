using Firebrand.Reflaction;

using System.Security.Cryptography;

namespace Firebrand.Security.Cryptography;

/// <summary>
/// Provides methods for hashing and verifying data using a specified hashing algorithm and salt.
/// </summary>
public class HashManager : IDisposable
{
    private readonly IHashStrategy hashStrategy;

    private HashManager(IHashStrategy hashStrategy)
    {
        this.hashStrategy = hashStrategy;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="HashManager"/> class with the specified hash strategy.
    /// </summary>
    /// <param name="hashStrategy">The hash strategy to use for hashing and verifying data.</param>
    /// <returns>A new instance of the <see cref="HashManager"/> class with the specified hash strategy.</returns>
    public static HashManager Create(IHashStrategy hashStrategy) => new(hashStrategy);

    /// <summary>
    /// Creates a new instance of the <see cref="HashManager"/> class with the default hash strategy specified by the generic type parameter.
    /// </summary>
    /// <typeparam name="T">The type of the default hash strategy.</typeparam>
    /// <returns>A new instance of the <see cref="HashManager"/> class with the default hash strategy specified by the generic type parameter.</returns>
    public static HashManager Create<T>() where T : IHashStrategy
    {
        T createdStrategy = ObjectCache.GetOrCreateInstance<T>();

        return Create(createdStrategy);
    }

    /// <summary>
    /// Generates a cryptographically secure random salt of the specified size.
    /// </summary>
    /// <param name="size">The size of the salt to generate, in bytes.</param>
    /// <returns>A byte array containing the generated salt.</returns>
    public static byte[] CreateSalt(int size = 16)
    {
        var buffer = new byte[size];
        RandomNumberGenerator.Fill(buffer);
        return buffer;
    }

    /// <summary>
    /// Computes the hash of the specified byte array using the specified hash strategy and no salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <returns>The computed hash.</returns>
    public byte[] Hash(byte[] input)
    {
        return hashStrategy.Hash(input);
    }

    /// <summary>
    /// Computes the hash of the specified byte array using the specified hash strategy and salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <param name="salt">The salt to use for hashing the byte array.</param>
    /// <returns>The computed hash.</returns>
    public byte[] Hash(byte[] input, byte[] salt)
    {
        return hashStrategy.Hash(input, salt);
    }

    /// <summary>
    /// Computes the hash of the specified string using the specified hash strategy and salt, and returns the result as a Base64-encoded string.
    /// </summary>
    /// <param name="input">The string to hash.</param>
    /// <param name="salt">The salt to use for hashing the string.</param>
    /// <returns>The computed hash as a Base64-encoded string.</returns>
    public string Hash(string input, string salt)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);
        var hashedBytes = Hash(inputBytes, saltBytes);
        return System.Convert.ToBase64String(hashedBytes);
    }

    /// <summary>
    /// Verifies whether the specified string and salt match the specified hash value, using the specified hash strategy.
    /// </summary>
    /// <param name="input">The string to verify.</param>
    /// <param name="salt">The salt that was used when hashing the string.</param>
    /// <param name="hash">The hash value to compare the computed hash against.</param>
    /// <returns>True if the specified string and salt match the specified hash value; otherwise, false.</returns>
    public bool Verify(string input, string salt, string hash)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);
        var hashBytes = System.Convert.FromBase64String(hash);
        return Verify(inputBytes, saltBytes, hashBytes);
    }

    /// <summary>
    /// Verifies whether the specified byte array and salt match the specified hash value, using the specified hash strategy.
    /// </summary>
    /// <param name="input">The byte array to verify.</param>
    /// <param name="salt">The salt that was used when hashing the byte array.</param>
    /// <param name="hash">The hash value to compare the computed hash against.</param>
    /// <returns>True if the specified byte array and salt match the specified hash value; otherwise, false.</returns>
    public bool Verify(byte[] input, byte[] salt, byte[] hash)
    {
        var hashedBytes = Hash(input, salt);
        return hashedBytes.SequenceEqual(hash);
    }

    /// <summary>
    /// Computes the hash of the specified byte array asynchronously using the specified hash strategy and no salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <returns>The computed hash as a byte array.</returns>
    public async Task<byte[]> HashAsync(byte[] input)
    {
        return await hashStrategy.HashAsync(input).ConfigureAwait(false);
    }

    /// <summary>
    /// Computes the hash of the specified byte array asynchronously using the specified hash strategy and salt.
    /// </summary>
    /// <param name="input">The byte array to hash.</param>
    /// <param name="salt">The salt to use for hashing the byte array.</param>
    /// <returns>The computed hash as a byte array.</returns>
    public async Task<byte[]> HashAsync(byte[] input, byte[] salt)
    {
        return await hashStrategy.HashAsync(input, salt).ConfigureAwait(false);
    }

    /// <summary>
    /// Computes the hash of the specified string asynchronously using the specified hash strategy and salt, and returns the result as a Base64-encoded string.
    /// </summary>
    /// <param name="input">The string to hash.</param>
    /// <param name="salt">The salt to use for hashing the string.</param>
    /// <returns>The computed hash as a Base64-encoded string.</returns>
    public async Task<string> HashAsync(string input, string salt)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);
        var hashedBytes = await HashAsync(inputBytes, saltBytes);
        return System.Convert.ToBase64String(hashedBytes);
    }

    /// <summary>
    /// Verifies whether the specified string and salt match the specified hash value, using the specified hash strategy.
    /// </summary>
    /// <param name="input">The string to verify.</param>
    /// <param name="salt">The salt that was used when hashing the string.</param>
    /// <param name="hash">The hash value to compare the computed hash against.</param>
    /// <returns>True if the specified string and salt match the specified hash value; otherwise, false.</returns>
    public async Task<bool> VerifyAsync(string input, string salt, string hash)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);
        var hashBytes = System.Convert.FromBase64String(hash);
        return await VerifyAsync(inputBytes, saltBytes, hashBytes);
    }

    /// <summary>
    /// Verifies whether the specified byte array and salt match the specified hash value, using the specified hash strategy.
    /// </summary>
    /// <param name="input">The byte array to verify.</param>
    /// <param name="salt">The salt that was used when hashing the byte array.</param>
    /// <param name="hash">The hash value to compare the computed hash against.</param>
    /// <returns>True if the specified byte array and salt match the specified hash value; otherwise, false.</returns>
    public async Task<bool> VerifyAsync(byte[] input, byte[] salt, byte[] hash)
    {
        var hashedBytes = await HashAsync(input, salt);
        return hashedBytes.SequenceEqual(hash);
    }

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="HashManager"/> class.
    /// </summary>
    public void Dispose()
    {
        hashStrategy.Dispose();
        GC.SuppressFinalize(this);
    }
}