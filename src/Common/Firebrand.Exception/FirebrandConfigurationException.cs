
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebrand.Exception;

/// <summary>
/// Represents an exception that occurs during configuration in the Firebrand application.
/// </summary>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class FirebrandConfigurationException : FirebrandException
{
    public const string ErrorCode = "ConfigurationError";

    /// <summary>
    /// Gets the type of the configuration that caused the exception.
    /// </summary>
    public Type ConfigurationType { get; }

    /// <summary>
    /// Gets the property name that caused the exception.
    /// </summary>
    public string Property { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FirebrandConfigurationException"/> class with the specified configuration type and property name.
    /// </summary>
    /// <param name="configurationType">The type of the configuration that caused the exception.</param>
    /// <param name="property">The property name that caused the exception.</param>
    public FirebrandConfigurationException(Type configurationType, string property) : base(ErrorCode, "Configuration error in " + configurationType.Name + " for property " + property)
    {
        ConfigurationType = configurationType;
        Property = property;
    }

    /// <summary>
    /// Returns a string that represents the current object for debugging purposes.
    /// </summary>
    /// <returns>A string that represents the current object for debugging purposes.</returns>
    private string GetDebuggerDisplay()
    {
        return $"{ConfigurationType.Name}-{Property}";
    }
}
