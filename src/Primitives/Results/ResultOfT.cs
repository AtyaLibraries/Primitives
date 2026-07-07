// <copyright file="ResultOfT.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Primitives.Errors;

namespace Atya.Foundation.Primitives.Results;

/// <summary>
/// Represents the outcome of an operation that can produce a value.
/// </summary>
/// <typeparam name="TValue">The value type.</typeparam>
public sealed class Result<TValue> : Result
{
    private Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value for a successful result.
    /// </summary>
    public TValue? Value
    {
        get;
    }

    /// <summary>
    /// Creates a successful value result.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <returns>The successful value result.</returns>
    public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, Error.None);

    /// <summary>
    /// Creates a failed value result.
    /// </summary>
    /// <param name="error">The failure error.</param>
    /// <returns>The failed value result.</returns>
    public static new Result<TValue> Failure(Error error) => new Result<TValue>(default, false, error);
}
