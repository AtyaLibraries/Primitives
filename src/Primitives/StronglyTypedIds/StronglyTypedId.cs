// <copyright file="StronglyTypedId.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.StronglyTypedIds;

/// <summary>
/// Base type for strongly typed identifiers.
/// </summary>
/// <typeparam name="TValue">The underlying identifier value type.</typeparam>
public abstract record StronglyTypedId<TValue>
    where TValue : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StronglyTypedId{TValue}"/> record.
    /// </summary>
    /// <param name="value">The non-null identifier value.</param>
    protected StronglyTypedId(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Gets the underlying identifier value.
    /// </summary>
    public TValue Value
    {
        get;
        init;
    }

    /// <summary>
    /// Returns the string representation of the underlying value.
    /// </summary>
    /// <returns>The value string, or an empty string when the value returns <see langword="null"/>.</returns>
    public sealed override string ToString()
    {
        return Value.ToString() ?? string.Empty;
    }
}
