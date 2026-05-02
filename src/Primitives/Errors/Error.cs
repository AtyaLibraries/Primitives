// <copyright file="Error.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.Errors;

public sealed record Error
{
    public Error(string code, string message)
        : this(code, message, allowEmpty: false)
    {
    }

    private Error(string code, string message, bool allowEmpty)
    {
        if (!allowEmpty)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code);
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
        }

        Code = code;
        Message = message;
    }

    public string Code
    {
        get; init;
    }

    public string Message
    {
        get; init;
    }

    public static readonly Error None = new Error(string.Empty, string.Empty, allowEmpty: true);

    public static Error Create(string code, string message)
    {
        return new Error(code, message);
    }
}
