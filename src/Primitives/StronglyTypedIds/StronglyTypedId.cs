// <copyright file="StronglyTypedId.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.StronglyTypedIds;

public abstract record StronglyTypedId<TValue>
    where TValue : notnull
{
    protected StronglyTypedId(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        Value = value;
    }

    public TValue Value
    {
        get;
        init;
    }

    public sealed override string ToString()
    {
        return Value.ToString() ?? string.Empty;
    }
}
