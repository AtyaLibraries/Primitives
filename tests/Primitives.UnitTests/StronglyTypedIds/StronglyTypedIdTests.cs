using Atya.Foundation.Primitives.StronglyTypedIds;

namespace Atya.Foundation.Primitives.UnitTests.StronglyTypedIds;

public sealed class StronglyTypedIdTests
{
    [Fact]
    public void ToString_Should_Return_Underlying_Value_Text()
    {
        CustomerId id = new(Guid.Parse("11111111-1111-1111-1111-111111111111"));

        id.ToString().Should().Be("11111111-1111-1111-1111-111111111111");
    }

    [Fact]
    public void Constructor_Should_Throw_When_Value_Is_Null()
    {
        Action action = () => _ = new CustomerCode(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToString_Should_Return_Empty_When_Underlying_Value_Returns_Null_Text()
    {
        NullableTextId id = new(new NullTextValue());

        id.ToString().Should().BeEmpty();
    }

    private sealed record CustomerId(Guid Value) : StronglyTypedId<Guid>(Value);

    private sealed record CustomerCode(string Value) : StronglyTypedId<string>(Value);

    private sealed record NullableTextId(NullTextValue Value) : StronglyTypedId<NullTextValue>(Value);

    private sealed class NullTextValue
    {
        public override string? ToString()
        {
            return null;
        }
    }
}
