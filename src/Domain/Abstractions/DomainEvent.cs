namespace Domain.Abstractions;

/// <summary>
/// Represents the abstract domain event primitive.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="occuredOnUtc">The occured on date and time.</param>
    protected DomainEvent(Guid id, DateTime occuredOnUtc)
        : this()
    {
        Id = id;
        OccuredOnUtc = occuredOnUtc;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    private DomainEvent()
    {
    }

    public Guid Id { get ; init ; }

    public DateTime OccuredOnUtc { get ; init ; }
}
