using Atya.Foundation.Primitives.Paging;

namespace Atya.Foundation.Primitives.UnitTests.Paging;

public sealed class PagedResultTests
{
    private static readonly int[] ThreeItems = [1, 2, 3];
    private static readonly int[] OneItem = [1];

    [Fact]
    public void TotalPages_Should_Be_Calculated_Correctly()
    {
        PagedResult<int> result = new(ThreeItems, 2, 10, 25);

        result.TotalPages.Should().Be(3);
    }

    [Fact]
    public void TotalPages_Should_Be_Zero_When_TotalCount_Is_Zero()
    {
        PagedResult<int> result = new(Array.Empty<int>(), 1, 10, 0);

        result.TotalPages.Should().Be(0);
    }

    [Fact]
    public void HasPreviousPage_Should_Be_True_When_PageNumber_Greater_Than_One()
    {
        PagedResult<int> result = new(OneItem, 2, 10, 25);

        result.HasPreviousPage.Should().BeTrue();
    }

    [Fact]
    public void HasPreviousPage_Should_Be_False_When_PageNumber_Is_One()
    {
        PagedResult<int> result = new(OneItem, 1, 10, 25);

        result.HasPreviousPage.Should().BeFalse();
    }

    [Fact]
    public void HasNextPage_Should_Be_True_When_PageNumber_Is_Less_Than_TotalPages()
    {
        PagedResult<int> result = new(OneItem, 2, 10, 25);

        result.HasNextPage.Should().BeTrue();
    }

    [Fact]
    public void HasNextPage_Should_Be_False_When_PageNumber_Is_Last_Page()
    {
        PagedResult<int> result = new(OneItem, 3, 10, 25);

        result.HasNextPage.Should().BeFalse();
    }

    [Fact]
    public void Empty_Should_Return_Empty_Result()
    {
        PagedResult<int> result = PagedResult<int>.Empty(1, 20);

        result.Items.Should().BeEmpty();
        result.TotalCount.Should().Be(0);
        result.TotalPages.Should().Be(0);
        result.HasPreviousPage.Should().BeFalse();
        result.HasNextPage.Should().BeFalse();
    }

    [Fact]
    public void Constructor_Should_Throw_When_Items_Is_Null()
    {
        Action action = () => _ = new PagedResult<int>(null!, 1, 20, 0);

        action.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(0, 20, 0, "pageNumber")]
    [InlineData(1, 0, 0, "pageSize")]
    [InlineData(1, 20, -1, "totalCount")]
    public void Constructor_Should_Throw_When_Page_Metadata_Is_Invalid(
        int pageNumber,
        int pageSize,
        int totalCount,
        string expectedParamName)
    {
        Action action = () => _ = new PagedResult<int>(Array.Empty<int>(), pageNumber, pageSize, totalCount);

        action.Should()
            .Throw<ArgumentOutOfRangeException>()
            .Where(ex => ex.ParamName == expectedParamName);
    }
}
