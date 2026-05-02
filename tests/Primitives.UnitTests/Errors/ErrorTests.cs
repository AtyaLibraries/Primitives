using Atya.Foundation.Primitives.Errors;

namespace Atya.Foundation.Primitives.UnitTests.Errors;

public sealed class ErrorTests
{
    [Fact]
    public void Create_Should_Return_Error_When_Values_Are_Valid()
    {
        Error error = Error.Create("sample.code", "Sample message");

        error.Code.Should().Be("sample.code");
        error.Message.Should().Be("Sample message");
    }

    [Theory]
    [InlineData(null, "Message", "code")]
    [InlineData("", "Message", "code")]
    [InlineData(" ", "Message", "code")]
    [InlineData("sample.code", null, "message")]
    [InlineData("sample.code", "", "message")]
    [InlineData("sample.code", " ", "message")]
    public void Create_Should_Throw_When_Code_Or_Message_Is_Invalid(string? code, string? message, string expectedParamName)
    {
        Action action = () => Error.Create(code!, message!);

        action.Should()
            .Throw<ArgumentException>()
            .Where(ex => ex.ParamName == expectedParamName);
    }

    [Fact]
    public void Constructor_Should_Validate_Inputs()
    {
        Action action = () => _ = new Error(string.Empty, "Message");

        action.Should()
            .Throw<ArgumentException>()
            .Where(ex => ex.ParamName == "code");
    }

    [Fact]
    public void None_Should_Be_Empty_Error()
    {
        Error.None.Code.Should().BeEmpty();
        Error.None.Message.Should().BeEmpty();
    }
}
