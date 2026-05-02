// <copyright file="StronglyTypedId.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.StronglyTypedIds;

public abstract record StronglyTypedId<TValue>
    where TValue : notnull
{
    public StronglyTypedId(TValue value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
    }

    public TValue Value
    {
        get; init;
    }

    public sealed override string ToString()
    {
        return Value.ToString() ?? string.Empty;
    }
}
