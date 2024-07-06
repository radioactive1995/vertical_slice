using Todos.Domain;

namespace Todos.Core;

public interface ITodoRepository
{
    void AddTodo(TodoEntity todoEntity);
    void RemoveTodo(TodoEntity todoEntity);
    List<TodoEntity> GetAllTodos();
    TodoEntity? GetTodo(Guid Id);
}
