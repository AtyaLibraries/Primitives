// <copyright file="ValueObject.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Primitives.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }

    public bool Equals(ValueObject? other)
    {
        if (other is null || other.GetType() != this.GetType())
        {
            return false;
        }

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.GetEqualityComponents()
            .Aggregate(
                seed: 0,
                func: static (current, component) => HashCode.Combine(current, component));
    }

    protected abstract IEnumerable<object?> GetEqualityComponents();
}
