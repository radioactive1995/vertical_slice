using MediatR;
using Todos.Core;

namespace Todos.Todos;

public class CompleteTodoHandler(
    ITodoRepository todoRepository) : IRequestHandler<CompleteTodoCommand, CompleteTodoResponse>
{
    public Task<CompleteTodoResponse> Handle(CompleteTodoCommand command, CancellationToken cancellationToken)
    {
        var mapper = new CompleteTodoMapper();
        var todo = todoRepository.GetTodo(command.Id);

        if (todo == null) return Task.FromResult(new CompleteTodoResponse(Id: Guid.Empty, Content: null!, Completed: false));

        todo.Completed = false;

        var response = mapper.FromEntity(todo);

        return Task.FromResult(response);
    }
}
