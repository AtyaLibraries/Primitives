using Atya.Foundation.Primitives.Errors;
using Atya.Foundation.Primitives.Paging;
using Atya.Foundation.Primitives.Results;
using Atya.Foundation.Primitives.StronglyTypedIds;
using Atya.Foundation.Primitives.ValueObjects;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Primitives.Benchmarks;

/// <summary>
/// Runs the Atya.Foundation.Primitives benchmark suite.
/// </summary>
public static class Program
{
    /// <summary>
    /// Executes the benchmark suite.
    /// </summary>
    /// <param name="args">Command-line arguments passed to BenchmarkDotNet.</param>
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<PrimitiveBenchmarks>();
    }
}

/// <summary>
/// Benchmarks common primitive type operations.
/// </summary>
[MemoryDiagnoser]
[ShortRunJob]
public class PrimitiveBenchmarks
{
    private readonly Money _first = new(100, "USD");
    private readonly Money _second = new(100, "USD");
    private readonly PagedRequest _request = new(3, 25);

    /// <summary>
    /// Creates an error value.
    /// </summary>
    /// <returns>The created error.</returns>
    [Benchmark]
    public Error CreateError() => Error.Create("customer.email.invalid", "Customer email is invalid.");

    /// <summary>
    /// Creates a successful value result.
    /// </summary>
    /// <returns>The successful result.</returns>
    [Benchmark]
    public Result<int> CreateSuccessfulResult() => Result.Success(42);

    /// <summary>
    /// Creates a failed value result.
    /// </summary>
    /// <returns>The failed result.</returns>
    [Benchmark]
    public Result<int> CreateFailedResult() => Result.Failure<int>(Error.Create("sample.failure", "Failure."));

    /// <summary>
    /// Calculates the skip count for a paged request.
    /// </summary>
    /// <returns>The number of items to skip.</returns>
    [Benchmark]
    public int CalculateSkip() => _request.Skip;

    /// <summary>
    /// Creates an empty page result.
    /// </summary>
    /// <returns>The empty page result.</returns>
    [Benchmark]
    public PagedResult<int> CreateEmptyPage() => PagedResult<int>.Empty(1, 20);

    /// <summary>
    /// Creates a strongly typed identifier.
    /// </summary>
    /// <returns>The strongly typed identifier.</returns>
    [Benchmark]
    public StronglyTypedId<Guid> CreateStronglyTypedId() => new CustomerId(Guid.Parse("11111111-1111-1111-1111-111111111111"));

    /// <summary>
    /// Compares two value objects.
    /// </summary>
    /// <returns><see langword="true"/> when the values are equal.</returns>
    [Benchmark]
    public bool CompareValueObjects() => _first == _second;

    private sealed record CustomerId(Guid Value) : StronglyTypedId<Guid>(Value);

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
}
