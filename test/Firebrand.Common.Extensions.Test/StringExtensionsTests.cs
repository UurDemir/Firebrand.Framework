namespace Firebrand.Common.Extensions.Tests;

[TestFixture]
public class StringExtensionsTests
{
    [Test]
    public void FormatWith_ReturnsFormattedString()
    {
        // Arrange
        string text = "The {0} is {1} years old.";
        int age = 25;
        string name = "person";
        string expected = "The person is 25 years old.";

        // Act
        string actual = text.FormatWith(name, age);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void IsNullOrWhiteSpaceOrEmpty_ReturnsTrue_WhenStringIsNullOrWhiteSpace()
    {
        // Arrange
        string? nullString = null;
        string emptyString = string.Empty;
        string whitespaceString = "    ";

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        bool nullResult = nullString.IsNullOrWhiteSpaceOrEmpty();
#pragma warning restore CS8604 // Possible null reference argument.
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
        string nonEmptyString = "Hello, world!";

        // Act
        bool result = nonEmptyString.IsNullOrWhiteSpaceOrEmpty();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Truncate_ReturnsOriginalString_WhenLengthIsGreaterThanStringLength()
    {
        // Arrange
        string str = "The quick brown fox jumps over the lazy dog.";
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
        string str = "The quick brown fox jumps over the lazy dog.";
        int length = 10;
        string ellipsis = "...";
        string expected = "The quick...";

        // Act
        string actual = str.Truncate(length, ellipsis);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToTitleCase_ReturnsTitleCasedString()
    {
        // Arrange
        string str = "the quick brown fox";
        string expected = "The Quick Brown Fox";

        // Act
        string actual = str.ToTitleCase();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ContainsAny_ReturnsTrue_WhenStringContainsAnyOfSpecifiedCharacters()
    {
        // Arrange
        string str = "The quick brown fox jumps over the lazy dog.";
        char[] chars = { 'a', 'e', 'i', 'o', 'u' };

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result);
    }

    [Test]
    public void ContainsAny_ReturnsFalse_WhenStringDoesNotContainAnyOfSpecifiedCharacters()
    {
        // Arrange
        string str = "The quick brown fox jumps over the lazy dog.";
        char[] chars = { 'ü', 'ö', 'ç' };

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ContainsAny_WhenStringContainsAnyOfTheGivenCharacters_ReturnsTrue()
    {
        // Arrange
        string str = "hello world";
        char[] chars = { 'l', 'o' };

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result);
    }

    [Test]
    public void ContainsAny_WhenStringDoesNotContainAnyOfTheGivenCharacters_ReturnsFalse()
    {
        // Arrange
        string str = "hello world";
        char[] chars = { 'x', 'y', 'z' };

        // Act
        bool result = str.ContainsAny(chars);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveWhitespace_RemovesAllWhiteSpaceCharactersFromString()
    {
        // Arrange
        string str = " hello\tworld\n ";

        // Act
        string result = str.RemoveWhitespace();

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }

    [Test]
    public void IsNumeric_WhenStringContainsOnlyNumericCharacters_ReturnsTrue()
    {
        // Arrange
        string str = "12345";

        // Act
        bool result = str.IsNumeric();

        // Assert
        Assert.That(result);
    }

    [Test]
    public void IsNumeric_WhenStringContainsNonNumericCharacters_ReturnsFalse()
    {
        // Arrange
        string str = "12345a";

        // Act
        bool result = str.IsNumeric();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Left_ReturnsTheSpecifiedNumberOfCharactersFromTheBeginningOfTheString()
    {
        // Arrange
        string str = "hello world";
        int length = 5;

        // Act
        string result = str.Left(length);

        // Assert
        Assert.That(result, Is.EqualTo("hello"));
    }

    [Test]
    public void Left_ReturnsTheEntireStringIfTheSpecifiedLengthIsGreaterThanTheStringLength()
    {
        // Arrange
        string str = "hello world";
        int length = 20;

        // Act
        string result = str.Left(length);

        // Assert
        Assert.That(result, Is.EqualTo(str));
    }

    [Test]
    public void Right_ReturnsTheSpecifiedNumberOfCharactersFromTheEndOfTheString()
    {
        // Arrange
        string str = "hello world";
        int length = 5;

        // Act
        string result = str.Right(length);

        // Assert
        Assert.That(result, Is.EqualTo("world"));
    }

    [Test]
    public void Right_ReturnsTheEntireStringIfTheSpecifiedLengthIsGreaterThanTheStringLength()
    {
        // Arrange
        string str = "hello world";
        int length = 20;

        // Act
        string result = str.Right(length);

        // Assert
        Assert.That(result, Is.EqualTo(str));
    }
    [Test]
    public void RemoveFromEnd_RemovesSpecifiedNumberOfCharactersFromEndOfString()
    {
        string input = "abcdefg";
        string expectedOutput = "abcd";
        int count = 3;

        string actualOutput = input.RemoveFromEnd(count);

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void RemoveFromEnd_ReturnsEmptyStringIfCountIsEqualToStringLength()
    {
        string input = "abcdefg";
        int count = 7;

        string actualOutput = input.RemoveFromEnd(count);

        Assert.That(actualOutput, Is.EqualTo(string.Empty));
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrueIfStringContainsSubstringIgnoringCase()
    {
        string input = "The quick brown fox jumps over the lazy dog.";
        string substring = "brown fox";

        bool actualOutput = input.ContainsIgnoreCase(substring);

        Assert.That(actualOutput);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsFalseIfStringDoesNotContainSubstringIgnoringCase()
    {
        string input = "The quick brown fox jumps over the lazy dog.";
        string substring = "orange cat";

        bool actualOutput = input.ContainsIgnoreCase(substring);

        Assert.That(actualOutput, Is.False);
    }

    [Test]
    public void ToSnakeCase_ConvertsStringToSnakeCase()
    {
        string input = "SomeVariableName";
        string expectedOutput = "some_variable_name";

        string actualOutput = input.ToSnakeCase();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToKebabCase_ConvertsStringToKebabCase()
    {
        string input = "SomeOtherVariableName";
        string expectedOutput = "some-other-variable-name";

        string actualOutput = input.ToKebabCase();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToByteArray_ConvertsStringToByteArrayUsingUTF8Encoding()
    {
        string input = "Hello, world!";
        byte[] expectedOutput = "Hello, world!"u8.ToArray();

        byte[] actualOutput = input.ToByteArray();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void FromBase64_ConvertsBase64EncodedStringToByteArray()
    {
        string input = "SGVsbG8sIHdvcmxkIQ==";
        byte[] expectedOutput = "Hello, world!"u8.ToArray();

        byte[] actualOutput = input.FromBase64();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToBase64_ConvertsByteArrayToBase64EncodedString()
    {
        byte[] input = "Hello, world!"u8.ToArray();
        string expectedOutput = "SGVsbG8sIHdvcmxkIQ==";

        string actualOutput = input.ToBase64();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ReplaceMany_ReplacesMultipleSubstrings()
    {
        // Arrange
        var input = "The quick brown fox jumps over the lazy dog.";
        var replacements = new Dictionary<string, string>()
    {
        { "quick", "slow" },
        { "brown", "red" },
        { "lazy", "tired" }
    };
        var expectedOutput = "The slow red fox jumps over the tired dog.";

        // Act
        var actualOutput = input.ReplaceMany(replacements);

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void SplitAndTrim_SplitsAndTrimsString()
    {
        // Arrange
        var input = "  The quick   brown fox   ";
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
        var input = "The quick brown fox jumped over the lazy dog 123.";
        var expectedOutput = "the-quick-brown-fox-jumped-over-the-lazy-dog-123";

        // Act
        var actualOutput = input.ToSlug();

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void ToProperCase_ConvertsStringToProperCase()
    {
        // Arrange
        var input = "the quick brown fox. the lazy dog! it ran away? no way.";
        var expectedOutput = "The quick brown fox. The lazy dog! It ran away? No way.";

        // Act
        var actualOutput = input.ToProperCase();

        // Assert
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }
}