namespace Todos.Domain;

public class TodoEntity
{
    public TodoEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public required string Content { get; set; }
    public required bool Completed { get; set; }
}
