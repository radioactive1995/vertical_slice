using MediatR;

namespace Todos.Todos;

public class NotifiyDepartmentEventHandler(ILogger<NotifiyDepartmentEventHandler> logger) : INotificationHandler<AddTodoEvent>
{
    public Task Handle(AddTodoEvent @event, CancellationToken cancellationToken)
    {

    }
}
