using MediatR;

namespace Todos.Todos;

public class NotifiyDepartmentEventHandler(ILogger<NotifiyDepartmentEventHandler> logger) : INotificationHandler<AddTodoEvent>
{
    public Task Handle(AddTodoEvent @event, CancellationToken cancellationToken)
    {
        logger.LogInformation("Todo with id {todoId} has been created, notifying the department.", @event.TodoId);
        return Task.CompletedTask;
    }
}
