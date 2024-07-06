using MediatR;
using Todos.Domain.Shared;

namespace Todos.Todos;

public record AddTodoEvent(Guid TodoId) : DomainEvent, INotification;