using Atya.Foundation.Primitives.ValueObjects;

namespace Atya.Foundation.Primitives.UnitTests.ValueObjects;

public sealed class ValueObjectTests
{
    [Fact]
    public void Equal_ValueObjects_Should_Be_Equal()
    {
        Money first = new(100, "USD");
        Money second = new(100, "USD");

        first.Should().Be(second);
        (first == second).Should().BeTrue();
    }

    [Fact]
    public void Different_ValueObjects_Should_Not_Be_Equal()
    {
        Money first = new(100, "USD");
        Money second = new(200, "USD");

        first.Should().NotBe(second);
        (first != second).Should().BeTrue();
    }

    [Fact]
    public void Equal_ValueObjects_Should_Have_Same_HashCode()
    {
        Money first = new(100, "USD");
        Money second = new(100, "USD");

        first.GetHashCode().Should().Be(second.GetHashCode());
    }

    [Fact]
    public void ValueObject_Should_Not_Equal_Null()
    {
        Money first = new(100, "USD");

#pragma warning disable CA1508
        first.Equals(null).Should().BeFalse();
        (first == null).Should().BeFalse();
        (first != null).Should().BeTrue();
#pragma warning restore CA1508
    }

    [Fact]
    public void ValueObject_Should_Not_Equal_Different_Runtime_Type()
    {
        Money money = new(100, "USD");
        Distance distance = new(100);

        money.Equals(distance).Should().BeFalse();
    }

    [Fact]
    public void ValueObject_Should_Not_Equal_NonValueObject()
    {
        Money money = new(100, "USD");

        money.Equals("USD").Should().BeFalse();
    }

    private sealed class Money : ValueObject
    {
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount
        {
            get;
        }

        public string Currency
        {
            get;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }

    private sealed class Distance : ValueObject
    {
        public Distance(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount
        {
            get;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
