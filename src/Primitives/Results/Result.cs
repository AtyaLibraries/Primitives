// <copyright file="Result.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Abstractions;
using Atya.Foundation.Guards;
using Atya.Foundation.Primitives.Errors;

namespace Atya.Foundation.Primitives.Results;

/// <summary>
/// Represents the outcome of an operation.
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the result is successful.</param>
    /// <param name="error">The error associated with a failed result.</param>
    protected internal Result(bool isSuccess, Error error)
    {
        Guard.AgainstNull(error);

        if (isSuccess && error != Error.None)
        {
            throw new ArgumentException("Successful result cannot contain an error.", nameof(error));
        }

        if (!isSuccess && error == Error.None)
        {
            throw new ArgumentException("Failed result must contain an error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the result is successful.
    /// </summary>
    public bool IsSuccess
    {
        get;
    }

    /// <summary>
    /// Gets a value indicating whether the result is failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with a failed result.
    /// </summary>
    public Error Error
    {
        get;
    }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>The successful result.</returns>
    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    /// <param name="error">The failure error.</param>
    /// <returns>The failed result.</returns>
    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }

    /// <summary>
    /// Creates a successful result carrying a value.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>The successful value result.</returns>
    public static Result<TValue> Success<TValue>(TValue value)
    {
        return Result<TValue>.Success(value);
    }

    /// <summary>
    /// Creates a failed result carrying a value type.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="error">The failure error.</param>
    /// <returns>The failed value result.</returns>
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return Result<TValue>.Failure(error);
    }
}
