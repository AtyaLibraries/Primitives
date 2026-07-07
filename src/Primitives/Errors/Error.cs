// <copyright file="Error.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Foundation.Guards;

namespace Atya.Foundation.Primitives.Errors;

/// <summary>
/// Represents a stable error code and human-readable message.
/// </summary>
public sealed record Error
{
    /// <summary>
    /// Gets the sentinel value representing no error.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, allowEmpty: true);

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> record.
    /// </summary>
    /// <param name="code">The stable error code.</param>
    /// <param name="message">The human-readable error message.</param>
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

    /// <summary>
    /// Gets the stable error code.
    /// </summary>
    public string Code
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the human-readable error message.
    /// </summary>
    public string Message
    {
        get;
        init;
    }

    /// <summary>
    /// Creates an error from a stable code and message.
    /// </summary>
    /// <param name="code">The stable error code.</param>
    /// <param name="message">The human-readable error message.</param>
    /// <returns>The created error.</returns>
    public static Error Create(string code, string message)
    {
        return new Error(code, message);
    }
}
