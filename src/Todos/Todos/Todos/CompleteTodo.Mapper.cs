using FastEndpoints;
using Todos.Domain;

namespace Todos.Todos;

public class CompleteTodoMapper : Mapper<CompleteTodoCommand, CompleteTodoResponse, TodoEntity>
{
    public override CompleteTodoResponse FromEntity(TodoEntity e)
    {
        return new CompleteTodoResponse(e.Id, e.Content, e.Completed);
    }
}
