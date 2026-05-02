using Atya.Foundation.Primitives.Paging;

namespace Atya.Foundation.Primitives.UnitTests.Paging;

public sealed class PagedRequestTests
{
    [Fact]
    public void Constructor_Should_Use_Default_Page_Values()
    {
        PagedRequest request = new();

        request.PageNumber.Should().Be(1);
        request.PageSize.Should().Be(20);
        request.Skip.Should().Be(0);
    }

    [Fact]
    public void Skip_Should_Be_Calculated_From_Page_And_Size()
    {
        PagedRequest request = new(3, 25);

        request.Skip.Should().Be(50);
    }

    [Theory]
    [InlineData(0, 20, "pageNumber")]
    [InlineData(-1, 20, "pageNumber")]
    [InlineData(1, 0, "pageSize")]
    [InlineData(1, -1, "pageSize")]
    public void Constructor_Should_Throw_When_Page_Values_Are_Invalid(
        int pageNumber,
        int pageSize,
        string expectedParamName)
    {
        Action action = () => _ = new PagedRequest(pageNumber, pageSize);

        action.Should()
            .Throw<ArgumentOutOfRangeException>()
            .Where(ex => ex.ParamName == expectedParamName);
    }

    [Fact]
    public void Skip_Should_Throw_When_Calculation_Overflows()
    {
        PagedRequest request = new(int.MaxValue, int.MaxValue);

        Action action = () => _ = request.Skip;

        action.Should().Throw<OverflowException>();
    }
}
