using MediatR;
using Todos.Core;

namespace Todos.Todos;

public class GetTodosHandler(ITodoRepository todoRepository) : IRequestHandler<GetTodosQuery, GetTodosResponse[]>
{
    public Task<GetTodosResponse[]> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var mapper = new GetTodosMapper();

        var todos = todoRepository.GetAllTodos().ToArray();

        var response = mapper.FromEntity(todos);

        return Task.FromResult(response);
    }
}
