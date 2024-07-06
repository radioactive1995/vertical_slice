using FastEndpoints;
using Todos.Domain;

namespace Todos.Todos;

public class GetTodosMapper : Mapper<GetTodosQuery, GetTodosResponse[], TodoEntity[]>
{
    public override GetTodosResponse[] FromEntity(TodoEntity[] e)
    {
        return e.Select(todo => new GetTodosResponse(todo.Id, todo.Content, todo.Completed)).ToArray();
    }
}
