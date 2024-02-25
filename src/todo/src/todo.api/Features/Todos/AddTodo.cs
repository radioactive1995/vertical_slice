using FastEndpoints;
using FluentValidation;
using todo.api.Core;
using todo.api.Domain.Todos;
using static todo.api.Features.Todos.AddTodoEndpoint;

namespace todo.api.Features.Todos;

public record AddTodoRequest(string Title, string Description, bool Completed);

public record AddTodoResponse(Guid TodoId);

public class AddTodoValidator : Validator<AddTodoRequest>
{

    public AddTodoValidator()
    {
        RuleFor(dto => dto.Title).NotEmpty().WithErrorCode("AddTodoValidator.Title").WithMessage("Title cannot be empty");
        RuleFor(dto => dto.Description).NotEmpty().WithErrorCode("AddTodoValidator.Description").WithMessage("Description cannot be empty");
    }
}

public class AddTodoEndpoint : Endpoint<AddTodoRequest, AddTodoResponse, AddTodoMapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Post("todos");
    }
    public override async Task HandleAsync(AddTodoRequest req, CancellationToken ct)
    {
        var command = Map.ToCommand(req);

        var result = await command.ExecuteAsync(ct);

        await SendOkAsync(result);
    }

    public record AddTodoCommand(string Title, string Description, bool Completed, AddTodoMapper Map) : ICommand<AddTodoResponse>;

    public class AddTodoCommandHandler(ITodoRepository todoRepository) : CommandHandler<AddTodoCommand, AddTodoResponse>
    {
        public override async Task<AddTodoResponse> ExecuteAsync(AddTodoCommand command, CancellationToken ct)
        {
            
            var entity = command.Map.ToEntity(command);

            todoRepository.AddTodo(entity);

            await Task.CompletedTask;

            return command.Map.FromEntity(entity);
        }
    }
}

public class AddTodoMapper : CommandMapper<AddTodoRequest, AddTodoResponse, AddTodoCommand, Todo>
{
    public override AddTodoCommand ToCommand(AddTodoRequest r) => new AddTodoCommand(r.Title, r.Description, r.Completed, this);

    public override Todo ToEntity(AddTodoCommand command) =>
        new()
        {
            Completed = command.Completed,
            CreatedDate = DateTime.UtcNow,
            Description = command.Description,
            Id = Guid.NewGuid(),
            Title = command.Title,
        };

    public override AddTodoResponse FromEntity(Todo entity)
        => new AddTodoResponse(entity.Id);
}


