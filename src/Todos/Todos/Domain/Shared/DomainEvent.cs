namespace Todos.Domain.Shared;

public abstract record DomainEvent
{
    Guid EventId { get; }
}
