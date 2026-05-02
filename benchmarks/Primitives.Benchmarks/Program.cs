using Atya.Foundation.Primitives.Errors;
using Atya.Foundation.Primitives.Paging;
using Atya.Foundation.Primitives.Results;
using Atya.Foundation.Primitives.StronglyTypedIds;
using Atya.Foundation.Primitives.ValueObjects;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Primitives.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<PrimitiveBenchmarks>();
    }
}

[MemoryDiagnoser]
[ShortRunJob]
public class PrimitiveBenchmarks
{
    private readonly Money _first = new(100, "USD");
    private readonly Money _second = new(100, "USD");
    private readonly PagedRequest _request = new(3, 25);

    [Benchmark]
    public Error CreateError() => Error.Create("customer.email.invalid", "Customer email is invalid.");

    [Benchmark]
    public Result<int> CreateSuccessfulResult() => Result.Success(42);

    [Benchmark]
    public Result<int> CreateFailedResult() => Result.Failure<int>(Error.Create("sample.failure", "Failure."));

    [Benchmark]
    public int CalculateSkip() => this._request.Skip;

    [Benchmark]
    public PagedResult<int> CreateEmptyPage() => PagedResult<int>.Empty(1, 20);

    [Benchmark]
    public StronglyTypedId<Guid> CreateStronglyTypedId() => new CustomerId(Guid.Parse("11111111-1111-1111-1111-111111111111"));

    [Benchmark]
    public bool CompareValueObjects() => this._first == this._second;

    private sealed record CustomerId(Guid Value) : StronglyTypedId<Guid>(Value);

    private sealed class Money : ValueObject
    {
        public Money(decimal amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
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
            yield return this.Amount;
            yield return this.Currency;
        }
    }
}
