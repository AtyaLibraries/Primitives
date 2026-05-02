// <copyright file="Error.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Guards;

namespace Atya.Foundation.Primitives.Errors;

public sealed record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, allowEmpty: true);

    public Error(string code, string message)
        : this(code, message, allowEmpty: false)
    {
    }

    private Error(string code, string message, bool allowEmpty)
    {
        if (!allowEmpty)
        {
            Guard.AgainstNullOrWhiteSpace(code);
            Guard.AgainstNullOrWhiteSpace(message);
        }

        Code = code;
        Message = message;
    }

    public string Code
    {
        get;
        init;
    }

    public string Message
    {
        get;
        init;
    }

    public static Error Create(string code, string message)
    {
        return new Error(code, message);
    }
}
