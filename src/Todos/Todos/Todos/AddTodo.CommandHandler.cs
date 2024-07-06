using MediatR;
using Todos.Core;

namespace Todos.Todos;

public class AddTodoCommandHandler(
    ITodoRepository repository,
    IPublisher publisher) : IRequestHandler<AddTodoCommand, AddTodoResponse>
{
    public Task<AddTodoResponse> Handle(AddTodoCommand command, CancellationToken cancellationToken)
    {
        var mapper = new AddTodoMapper();

        var entity = mapper.ToEntity(command);

        repository.AddTodo(entity);

        var response = mapper.FromEntity(entity);

        publisher.Publish(new AddTodoEvent(TodoId: entity.Id));

        return Task.FromResult(response);
    }
}
