namespace Firebrand.Common.Extensions.Test;

[TestFixture]
public class StringExtensionsTests
{
    [Test]
    public void FormatWith_ReturnsFormattedString()
    {
        // Arrange
        const string text = "The {0} is {1} years old.";
        const int age = 25;
        const string name = "person";
        const string expected = "The person is 25 years old.";

        // Act
        string actual = text.FormatWith(name, age);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void IsNullOrWhiteSpaceOrEmpty_ReturnsTrue_WhenStringIsNullOrWhiteSpace()
    {
        // Arrange
        const string? nullString = null;
        string emptyString = string.Empty;
        const string whitespaceString = "    ";

        // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        bool nullResult = nullString.IsNullOrWhiteSpaceOrEmpty();
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        bool emptyResult = emptyString.IsNullOrWhiteSpaceOrEmpty();
        bool whitespaceResult = whitespaceString.IsNullOrWhiteSpaceOrEmpty();
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(nullResult);
            Assert.That(emptyResult);
            Assert.That(whitespaceResult);
        });
    }

    [Test]
    public void IsNullOrWhiteSpaceOrEmpty_ReturnsFalse_WhenStringIsNotEmptyAndNotWhiteSpace()
    {
        // Arrange
        const string nonEmptyString = "Hello, world!";

        // Act
        bool result = nonEmptyString.IsNullOrWhiteSpaceOrEmpty();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Truncate_ReturnsOriginalString_WhenLengthIsGreaterThanStringLength()
    {
        // Arrange
        const string str = "The quick brown fox jumps over the lazy dog.";
        int length = str.Length;

        // Act
        string truncated = str.Truncate(length);

        // Assert
        Assert.That(truncated, Is.EqualTo(str));
    }

    [Test]
    public void Truncate_ReturnsTruncatedString_WhenLengthIsLessThanStringLength()
    {
        // Arrange
        const string str = "The quick brown fox jumps over the lazy dog.";
        const int length = 10;
        const string ellipsis = "...";
        const string expected = "The quick...";

        // Act
        string actual = str.Truncate(length, ellipsis);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToTitleCase_ReturnsTitleCasedString()
    {
        // Arrange
        const string str = "the quick brown fox";
        const string expected = "The Quick Brown Fox";

        // Act
        string actual = str.ToTitleCase();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ContainsAny_ReturnsTrue_WhenStringContainsAnyOfSpecifiedCharacters()
    {
        // Arrange
        const string str = "The quick brown fox jumps over the lazy dog.";
        char[] chars = ['a', 'e', 'i', 'o', 'u'];

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result);
    }

    [Test]
    public void ContainsAny_ReturnsFalse_WhenStringDoesNotContainAnyOfSpecifiedCharacters()
    {
        // Arrange
        const string str = "The quick brown fox jumps over the lazy dog.";
        char[] chars = ['ü', 'ö', 'ç'];

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ContainsAny_WhenStringContainsAnyOfTheGivenCharacters_ReturnsTrue()
    {
        // Arrange
        const string str = "hello world";
        char[] chars = ['l', 'o'];

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result);
    }

    [Test]
    public void ContainsAny_WhenStringDoesNotContainAnyOfTheGivenCharacters_ReturnsFalse()
    {
        // Arrange
        const string str = "hello world";
        char[] chars = ['x', 'y', 'z'];

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveWhitespace_RemovesAllWhiteSpaceCharactersFromString()
    {
        // Arrange
        const string str = " hello\tworld\n ";

        // Act
        string result = str.RemoveWhitespace();

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }

    [Test]
    public void IsNumeric_WhenStringContainsOnlyNumericCharacters_ReturnsTrue()
    {
        // Arrange
        const string str = "12345";

        // Act
        bool result = str.IsNumeric();

        // Assert
        Assert.That(result);
    }

    [Test]
    public void IsNumeric_WhenStringContainsNonNumericCharacters_ReturnsFalse()
    {
        // Arrange
        const string str = "12345a";

        // Act
        bool result = str.IsNumeric();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Left_ReturnsTheSpecifiedNumberOfCharactersFromTheBeginningOfTheString()
    {
        // Arrange
        const string str = "hello world";
        const int length = 5;

        // Act
        string result = str.Left(length);

        // Assert
        Assert.That(result, Is.EqualTo("hello"));
    }

    [Test]
    public void Left_ReturnsTheEntireStringIfTheSpecifiedLengthIsGreaterThanTheStringLength()
    {
        // Arrange
        const string str = "hello world";
        const int length = 20;

        // Act
        string result = str.Left(length);

        // Assert
        Assert.That(result, Is.EqualTo(str));
    }

    [Test]
    public void Right_ReturnsTheSpecifiedNumberOfCharactersFromTheEndOfTheString()
    {
        // Arrange
        const string str = "hello world";
        const int length = 5;

        // Act
        string result = str.Right(length);

        // Assert
        Assert.That(result, Is.EqualTo("world"));
    }

    [Test]
    public void Right_ReturnsTheEntireStringIfTheSpecifiedLengthIsGreaterThanTheStringLength()
    {
        // Arrange
        const string str = "hello world";
        const int length = 20;

        // Act
        string result = str.Right(length);

        // Assert
        Assert.That(result, Is.EqualTo(str));
    }
    [Test]
    public void RemoveFromEnd_RemovesSpecifiedNumberOfCharactersFromEndOfString()
    {
        const string input = "abcdefg";
        const string expectedOutput = "abcd";
        const int count = 3;

        string actualOutput = input.RemoveFromEnd(count);

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void RemoveFromEnd_ReturnsEmptyStringIfCountIsEqualToStringLength()
    {
        const string input = "abcdefg";
        const int count = 7;

        string actualOutput = input.RemoveFromEnd(count);

        Assert.That(actualOutput, Is.EqualTo(string.Empty));
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrueIfStringContainsSubstringIgnoringCase()
    {
        const string input = "The quick brown fox jumps over the lazy dog.";
        const string substring = "brown fox";

        bool actualOutput = input.ContainsIgnoreCase(substring);

        Assert.That(actualOutput);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsFalseIfStringDoesNotContainSubstringIgnoringCase()
    {
        const string input = "The quick brown fox jumps over the lazy dog.";
        const string substring = "orange cat";

        bool actualOutput = input.ContainsIgnoreCase(substring);

        Assert.That(actualOutput, Is.False);
    }

    [Test]
    public void ToSnakeCase_ConvertsStringToSnakeCase()
    {
        const string input = "SomeVariableName";
        const string expectedOutput = "some_variable_name";

        string actualOutput = input.ToSnakeCase();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToKebabCase_ConvertsStringToKebabCase()
    {
        const string input = "SomeOtherVariableName";
        const string expectedOutput = "some-other-variable-name";

        string actualOutput = input.ToKebabCase();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToByteArray_ConvertsStringToByteArrayUsingUTF8Encoding()
    {
        const string input = "Hello, world!";
        byte[] expectedOutput = "Hello, world!"u8.ToArray();

        byte[] actualOutput = input.ToByteArray();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void FromBase64_ConvertsBase64EncodedStringToByteArray()
    {
        const string input = "SGVsbG8sIHdvcmxkIQ==";
        byte[] expectedOutput = "Hello, world!"u8.ToArray();

        byte[] actualOutput = input.FromBase64();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToBase64_ConvertsByteArrayToBase64EncodedString()
    {
        byte[] input = "Hello, world!"u8.ToArray();
        const string expectedOutput = "SGVsbG8sIHdvcmxkIQ==";

        string actualOutput = input.ToBase64();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ReplaceMany_ReplacesMultipleSubstrings()
    {
        // Arrange
        const string input = "The quick brown fox jumps over the lazy dog.";
        var replacements = new Dictionary<string, string>()
    {
        { "quick", "slow" },
        { "brown", "red" },
        { "lazy", "tired" }
    };
        const string expectedOutput = "The slow red fox jumps over the tired dog.";

        // Act
        var actualOutput = input.ReplaceMany(replacements);

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void SplitAndTrim_SplitsAndTrimsString()
    {
        // Arrange
        const string input = "  The quick   brown fox   ";
        var separators = new char[] { ' ' };
        var expectedOutput = new string[] { "The", "quick", "brown", "fox" };

        // Act
        var actualOutput = input.SplitAndTrim(separators);

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToSlug_ConvertsStringToSlug()
    {
        // Arrange
        const string input = "The quick brown fox jumped over the lazy dog 123.";
        const string expectedOutput = "the-quick-brown-fox-jumped-over-the-lazy-dog-123";

        // Act
        var actualOutput = input.ToSlug();

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToProperCase_ConvertsStringToProperCase()
    {
        // Arrange
        const string input = "the quick brown fox. the lazy dog! it ran away? no way.";
        const string expectedOutput = "The quick brown fox. The lazy dog! It ran away? No way.";

        // Act
        var actualOutput = input.ToProperCase();

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }
}