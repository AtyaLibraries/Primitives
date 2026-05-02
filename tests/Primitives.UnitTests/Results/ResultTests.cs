using Atya.Foundation.Primitives.Errors;
using Atya.Foundation.Primitives.Results;

namespace Atya.Foundation.Primitives.UnitTests.Results;

public sealed class ResultTests
{
    [Fact]
    public void Success_Should_Create_Successful_Result()
    {
        Result result = Result.Success();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void Failure_Should_Create_Failed_Result()
    {
        Error error = Error.Create("result.failure", "Failure happened");

        Result result = Result.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void Failure_Should_Throw_When_Error_Is_Null()
    {
        Action action = () => _ = Result.Failure(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Generic_Success_Should_Create_Result_With_Value()
    {
        Result<int> result = Result.Success(42);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void Generic_Failure_Should_Create_Result_With_Error()
    {
        Error error = Error.Create("result.failure", "Failure happened");

        Result<int> result = Result.Failure<int>(error);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [Fact]
    public void Creating_Success_With_Error_Should_Throw()
    {
        Action action = () => _ = new TestResult(true, Error.Create("invalid", "invalid"));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Creating_Failure_With_None_Error_Should_Throw()
    {
        Action action = () => _ = new TestResult(false, Error.None);

        action.Should().Throw<ArgumentException>();
    }

    private sealed class TestResult : Result
    {
        public TestResult(bool isSuccess, Error error)
            : base(isSuccess, error)
        {
        }
    }
}
