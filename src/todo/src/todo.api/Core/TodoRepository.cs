using System.Collections.Concurrent;
using todo.api.Domain.Todos;

namespace todo.api.Core;

public class TodoRepository(List<Todo> Todos) : ITodoRepository
{
    public void AddTodo(Todo todo) => Todos.Add(todo);
    public IEnumerable<Todo> GetPageTodos(int pageNumber, int pageSize)
        => Todos.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    public IEnumerable<Todo> GetTodos() => Todos;
}
