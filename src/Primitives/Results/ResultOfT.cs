// <copyright file="ResultOfT.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Primitives.Errors;

namespace Atya.Foundation.Primitives.Results;

public sealed class Result<TValue> : Result
{
    private Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public TValue? Value
    {
        get;
    }

    public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, Error.None);

    public static new Result<TValue> Failure(Error error) => new Result<TValue>(default, false, error);
}
