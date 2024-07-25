namespace Domain.Abstractions;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    protected AggregateRoot(Guid id) : base(id) { }

    protected AggregateRoot() : base() { }

    private readonly IList<IDomainEvent> doaminEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => doaminEvents.AsReadOnly();

    public void RaiseDomainEvent(IDomainEvent @event) => doaminEvents.Add(@event);

    public void ClearDomainEvent() => doaminEvents.Clear();
}

