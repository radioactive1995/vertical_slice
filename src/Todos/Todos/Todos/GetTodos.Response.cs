namespace Todos.Todos;

public record GetTodosResponse(Guid Id, string Content, bool Completed);
