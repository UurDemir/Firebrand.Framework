using System.Globalization;
using System.Text;

namespace Firebrand.Common.Extensions;

/// <summary>
/// Provides extension methods for string manipulation.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
    /// </summary>
    /// <param name="text">The string to format.</param>
    /// <param name="parameters">The objects to format.</param>
    /// <returns>A formatted string.</returns>
    public static string FormatWith(this string text, params object?[] parameters)
    {
        return string.Format(text, parameters);
    }

    /// <summary>
    /// Determines whether a string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><c>true</c> if the string is null, empty, or consists only of white-space characters; otherwise, <c>false</c>.</returns>
    public static bool IsNullOrWhiteSpaceOrEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str.Trim());
    }

    /// <summary>
    /// Truncates a string to the specified length and appends an optional ellipsis.
    /// </summary>
    /// <param name="str">The string to truncate.</param>
    /// <param name="length">The maximum length of the string.</param>
    /// <param name="ellipsis">The optional ellipsis to append.</param>
    /// <returns>The truncated string.</returns>
    public static string Truncate(this string str, int length, string ellipsis = "...")
    {
        if (str.Length <= length)
        {
            return str;
        }
        return string.Concat(str.AsSpan(0, length).TrimEnd(), ellipsis);
    }

    /// <summary>
    /// Converts a string to title case.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <returns>The title-cased string.</returns>
    public static string ToTitleCase(this string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }

    /// <summary>
    /// Determines whether a string contains any of the specified characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <param name="chars">The characters to search for.</param>
    /// <returns><c>true</c> if the string contains any of the specified characters; otherwise, <c>false</c>.</returns>
    public static bool ContainsAny(this string str, params char[] chars)
    {
        return str.IndexOfAny(chars) != -1;
    }

    /// <summary>
    /// Removes all white-space characters from a string.
    /// </summary>
    /// <param name="str">The string to modify.</param>
    /// <returns>The modified string.</returns>
    public static string RemoveWhitespace(this string str)
    {
        return new string(str.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }

    /// <summary>
    /// Determines whether a string contains only numeric characters.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>true if the string contains only numeric characters; otherwise, false.</returns>
    public static bool IsNumeric(this string str)
    {
        return str.All(char.IsDigit);
    }

    /// <summary>
    /// Returns a specified number of characters from the beginning of a string.
    /// </summary>
    /// <param name="str">The string to extract characters from.</param>
    /// <param name="length">The number of characters to extract.</param>
    /// <returns>A string containing the specified number of characters from the beginning of the input string.</returns>
    public static string Left(this string str, int length)
    {
        return str[..Math.Min(length, str.Length)];
    }

    /// <summary>
    /// Returns a specified number of characters from the end of a string.
    /// </summary>
    /// <param name="str">The string to extract characters from.</param>
    /// <param name="length">The number of characters to extract.</param>
    /// <returns>A string containing the specified number of characters from the end of the input string.</returns>
    public static string Right(this string str, int length)
    {
        return str[Math.Max(0, str.Length - length)..];
    }

    /// <summary>
    /// Removes a specified number of characters from the end of a string.
    /// </summary>
    /// <param name="str">The string to remove characters from.</param>
    /// <param name="count">The number of characters to remove from the end of the string.</param>
    /// <returns>A new string that is equivalent to the input string with the specified number of characters removed from the end.</returns>
    public static string RemoveFromEnd(this string str, int count)
    {
        if (count >= str.Length)
        {
            return string.Empty;
        }
        return str[..^count];
    }

    /// <summary>
    /// Determines whether a string contains a specified substring, ignoring case.
    /// </summary>
    /// <param name="str">The string to search in.</param>
    /// <param name="substring">The substring to search for.</param>
    /// <returns>true if the input string contains the specified substring; otherwise, false.</returns>
    public static bool ContainsIgnoreCase(this string str, string substring)
    {
        return str.Contains(substring, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Converts a string to snake case, with underscores between words.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <returns>The input string converted to snake case.</returns>
    public static string ToSnakeCase(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    }

    /// <summary>
    /// Converts a string to kebab case, with hyphens between words.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <returns>The input string converted to kebab case.</returns>
    public static string ToKebabCase(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString() : x.ToString())).ToLower();
    }

    /// <summary>
    /// Converts a string to a byte array using the UTF-8 encoding.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <returns>A byte array representing the string.</returns>
    public static byte[] ToByteArray(this string str)
    {
        return Encoding.UTF8.GetBytes(str);
    }

    /// <summary>
    /// Converts a base-64 encoded string to a byte array.
    /// </summary>
    /// <param name="str">The base-64 encoded string to convert.</param>
    /// <returns>A byte array representing the base-64 encoded string.</returns>
    public static byte[] FromBase64(this string str)
    {
        return Convert.FromBase64String(str);
    }

    /// <summary>
    /// Converts a byte array to a base-64 encoded string.
    /// </summary>
    /// <param name="bytes">The byte array to convert.</param>
    /// <returns>A base-64 encoded string representing the byte array.</returns>
    public static string ToBase64(this byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Replaces multiple substrings in a string with their corresponding replacements.
    /// </summary>
    /// <param name="str">The string to perform the replacements on.</param>
    /// <param name="replacements">A dictionary containing the substrings to replace and their replacements.</param>
    /// <returns>The string with the replacements performed.</returns>
    public static string ReplaceMany(this string str, IDictionary<string, string> replacements)
    {
        var builder = new StringBuilder(str);
        foreach (var replacement in replacements)
        {
            builder.Replace(replacement.Key, replacement.Value);
        }
        return builder.ToString();
    }

    /// <summary>
    /// Splits a string into substrings using the specified separators and trims each substring.
    /// </summary>
    /// <param name="str">The string to split.</param>
    /// <param name="separators">The separators to use for splitting the string.</param>
    /// <returns>An array of substrings.</returns>
    public static string[] SplitAndTrim(this string str, params char[] separators)
    {
        return str.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                  .Select(s => s.Trim())
                  .ToArray();
    }

    /// <summary>
    /// Converts a string to a slug by replacing non-alphanumeric characters with hyphens.
    /// </summary>
    /// <param name="str">The string to convert to a slug.</param>
    /// <returns>A slugified version of the string.</returns>
    public static string ToSlug(this string str)
    {
        var builder = new StringBuilder();
        var lastCharWasHyphen = false;
        foreach (var c in str)
        {
            if (char.IsLetterOrDigit(c))
            {
                builder.Append(char.ToLower(c));
                lastCharWasHyphen = false;
            }
            else if (!lastCharWasHyphen)
            {
                builder.Append('-');
                lastCharWasHyphen = true;
            }
        }
        return builder.ToString().Trim('-');
    }

    /// <summary>
    /// Converts the first character of each sentence in a string to uppercase and the rest to lowercase, while keeping the punctuation.
    /// </summary>
    /// <param name="str">The string to convert to proper case.</param>
    /// <returns>The string in proper case.</returns>
    public static string ToProperCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        int index = 0;
        var sentences = str.Split(new[] { ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
        var builder = new StringBuilder();
        foreach (var sentence in sentences)
        {   index += sentence.Length;

            int indexOfFirstLetter = 0;

            while (!char.IsLetter(sentence[indexOfFirstLetter]))
            {
                builder.Append(sentence[indexOfFirstLetter]);
                indexOfFirstLetter++;
            }

            builder.Append(char.ToUpper(sentence[indexOfFirstLetter]));
            builder.Append(sentence[(indexOfFirstLetter+1)..].ToLower());
            builder.Append(str[index++]);
        }
        return builder.ToString().Trim();
    }
}