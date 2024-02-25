namespace todo.api.Domain.Todos;

public class Todo
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
    public required DateTime CreatedDate { get; set; }
}

