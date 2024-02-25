using todo.api.Domain.Todos;

namespace todo.api.Core;

public interface ITodoRepository
{
    void AddTodo(Todo todo);
    IEnumerable<Todo> GetPageTodos(int pageNumber, int pageSize);
    IEnumerable<Todo> GetTodos();
}
