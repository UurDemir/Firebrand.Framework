
using System.Diagnostics;

namespace Firebrand.Exception;

/// <summary>
/// Represents an exception specific to the Firebrand application.
/// </summary>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class FirebrandException : System.Exception
{
    public const string UnknownError = "UnknownException";

    /// <summary>
    /// Gets the error code associated with this exception.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandException"/> class with a specified error code.
    /// </summary>
    /// <param name="code">The error code associated with this exception.</param>
    public FirebrandException(string code)
    {
        this.Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandException"/> class with a specified error code and message.
    /// </summary>
    /// <param name="code">The error code associated with this exception.</param>
    /// <param name="message">The message that describes the error.</param>
    public FirebrandException(string code, string message) : base(message)
    {
        this.Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandException"/> class with a specified error code, message, and inner exception.
    /// </summary>
    /// <param name="code">The error code associated with this exception.</param>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The inner exception that caused this exception to be thrown.</param>
    public FirebrandException(string code, string message, System.Exception innerException) : base(message, innerException)
    {
        this.Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandException"/> class with the default error code.
    /// </summary>
    public FirebrandException() : base()
    {
        Code = UnknownError;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandException"/> class with a specified message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The inner exception that caused this exception to be thrown.</param>
    public FirebrandException(string? message, System.Exception? innerException) : base(message, innerException)
    {
        Code = UnknownError;
    }

    private string GetDebuggerDisplay()
    {
        return $"{Code}-{Message}";
    }
}
