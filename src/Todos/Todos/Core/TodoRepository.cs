using Todos.Domain;

namespace Todos.Core;

public class TodoRepository : ITodoRepository
{
    public TodoRepository()
    {
        Todos = new();
    }

    public List<TodoEntity> Todos { get; }

    public void AddTodo(TodoEntity todoEntity) => Todos.Add(todoEntity);
    public void RemoveTodo(TodoEntity entity) => Todos.Remove(entity);
    public TodoEntity? GetTodo(Guid Id) => Todos.FirstOrDefault(t => t.Id == Id);
    public List<TodoEntity> GetAllTodos() => Todos;
}
