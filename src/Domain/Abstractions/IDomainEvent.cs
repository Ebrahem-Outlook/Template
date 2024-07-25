using MediatR;

namespace Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid Id { get; init; }

    DateTime OccuredOnUtc { get; init; }
}
