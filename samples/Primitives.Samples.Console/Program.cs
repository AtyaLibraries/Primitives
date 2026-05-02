using Atya.Foundation.Primitives.Errors;
using Atya.Foundation.Primitives.Paging;
using Atya.Foundation.Primitives.Results;
using Atya.Foundation.Primitives.StronglyTypedIds;
using Atya.Foundation.Primitives.ValueObjects;

OrderId orderId = new(Guid.NewGuid());
Money orderTotal = new(149.90m, "USD");
Error invalidEmail = Error.Create("customer.email.invalid", "Customer email is invalid.");
Result<OrderSummary> success = Result.Success(new OrderSummary(orderId, orderTotal));
Result<OrderSummary> failure = Result.Failure<OrderSummary>(invalidEmail);
PagedRequest pageRequest = new(2, 25);
PagedResult<OrderSummary> pagedResult = new(
    [new OrderSummary(orderId, orderTotal)],
    pageRequest.PageNumber,
    pageRequest.PageSize,
    51);

Console.WriteLine("Package: Atya.Foundation.Primitives");
Console.WriteLine($"Order id: {orderId}");
Console.WriteLine($"Order total: {orderTotal}");
Console.WriteLine($"Success result has value: {success.Value is not null}");
Console.WriteLine($"Failure code: {failure.Error.Code}");
Console.WriteLine($"Requested skip: {pageRequest.Skip}");
Console.WriteLine($"Has next page: {pagedResult.HasNextPage}");

file sealed record OrderSummary(OrderId OrderId, Money Total);

file sealed record OrderId(Guid Value) : StronglyTypedId<Guid>(Value);

file sealed class Money(decimal amount, string currency) : ValueObject
{
    public decimal Amount { get; } = amount;

    public string Currency { get; } = currency;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
