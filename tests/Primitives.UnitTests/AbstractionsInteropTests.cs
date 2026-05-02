using Atya.Foundation.Abstractions;

namespace Atya.Foundation.Primitives.UnitTests;

public sealed class AbstractionsInteropTests
{
    [Fact]
    public void IResult_Default_IsFailure_Should_Invert_IsSuccess()
    {
        IResult result = new ContractResult(false);

        result.IsFailure.Should().BeTrue();
    }

    private sealed class ContractResult : IResult
    {
        public ContractResult(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public bool IsSuccess
        {
            get;
        }
    }
}
