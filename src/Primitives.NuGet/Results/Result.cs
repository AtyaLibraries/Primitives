// <copyright file="Result.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Abstractions;
using Atya.Foundation.Primitives.Errors;

namespace Atya.Foundation.Primitives.Results;

public class Result : IResult
{
    protected internal Result(bool isSuccess, Error error)
    {
        ArgumentNullException.ThrowIfNull(error);

        if (isSuccess && error != Error.None)
        {
            throw new ArgumentException("Successful result cannot contain an error.", nameof(error));
        }

        if (!isSuccess && error == Error.None)
        {
            throw new ArgumentException("Failed result must contain an error.", nameof(error));
        }

        this.IsSuccess = isSuccess;
        this.Error = error;
    }

    public bool IsSuccess
    {
        get;
    }

    public bool IsFailure => !this.IsSuccess;

    public Error Error
    {
        get;
    }

    public static Result Success() => new Result(true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Success(value);

    public static Result<TValue> Failure<TValue>(Error error) => Result<TValue>.Failure(error);
}
