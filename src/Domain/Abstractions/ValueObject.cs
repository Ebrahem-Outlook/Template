namespace Domain.Abstractions;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? first, ValueObject? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(ValueObject? first, ValueObject? second) => !(first == second);

    /// <inheritdoce />
    public bool Equals(ValueObject? other) => other is not null && ValuesEqual(other);

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        if (obj is not ValueObject otherValueObject)
        {
            return false;
        }

        return ValuesEqual(otherValueObject);
    }

    /// <summary>
    /// Gets the atomic values of the value objects.
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<object> GetAtomicValue();

    /// <summary>
    /// Checks if the values of the specified value object are equal to the values of the current instance .
    /// </summary>
    /// <param name="other">The other value object.</param>
    /// <returns>True if the values of the specified value object are equal to the values of the current instance, otherwise false.</returns>
    private bool ValuesEqual(ValueObject other) => GetAtomicValue().SequenceEqual(other.GetAtomicValue());

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}