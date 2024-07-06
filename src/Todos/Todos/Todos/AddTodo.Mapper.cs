using FastEndpoints;
using Todos.Domain;

namespace Todos.Todos;

public class AddTodoMapper : Mapper<AddTodoCommand, AddTodoResponse, TodoEntity>
{
    public override TodoEntity ToEntity(AddTodoCommand r)
    {
        return new TodoEntity
        {
            Completed = r.Completed,
            Content = r.Content,
        };
    }

    public override AddTodoResponse FromEntity(TodoEntity e)
    {
        return new AddTodoResponse(Id: e.Id);
    }
}
