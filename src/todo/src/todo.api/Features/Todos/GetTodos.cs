using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using todo.api.Core;
using todo.api.Domain.Todos;

namespace todo.api.Features.Todos;

public record GetTodosRequest(uint? PageNumber, uint? PageSize);
public record GetTodosResponse(IEnumerable<object> Todos);

public class GetTodosValidator : Validator<GetTodosRequest>
{
    public GetTodosValidator()
    {
        RuleFor(dto => dto.PageNumber).InclusiveBetween(0u, uint.MaxValue).When(dto => dto.PageNumber.HasValue).WithErrorCode("GetTodosValidator.PageNumber").WithMessage("PageNumber has to be in range of valid unsigned integer values.");
        RuleFor(dto => dto.PageSize).InclusiveBetween(0u, uint.MaxValue).When(dto => dto.PageSize.HasValue).WithErrorCode("GetTodosValidator.PageSize").WithMessage("PageSize has to be in range of valid unsigned integer values.");
    }
}

public class GetTodosEndpoint : Endpoint<GetTodosRequest, GetTodosResponse, GetTodosMapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("todos");
    }
    public override async Task HandleAsync(GetTodosRequest req, CancellationToken ct)
    {
        var command = Map.ToCommand(req);

        var response = await command.ExecuteAsync(ct);

        await SendOkAsync(response);
    }
}

public record GetTodosCommand(int? PageNumber, int? PageSize, GetTodosMapper Map) : ICommand<GetTodosResponse>;

public class GetTodosCommandHandler(ITodoRepository todoRepository) : ICommandHandler<GetTodosCommand, GetTodosResponse>
{
    public Task<GetTodosResponse> ExecuteAsync(GetTodosCommand command, CancellationToken ct)
    {
        IEnumerable<Todo>? todos = null;
        if (command.PageNumber.HasValue && command.PageSize.HasValue)
            todos = todoRepository.GetPageTodos(command.PageNumber.Value, command.PageSize.Value);

        else todos = todoRepository.GetTodos();

        return Task.FromResult(command.Map.FromEntity(todos));
    }
}

public class GetTodosMapper : CommandMapper<GetTodosRequest, GetTodosResponse, GetTodosCommand, IEnumerable<Todo>>
{
    public override GetTodosCommand ToCommand(GetTodosRequest request)
    {
        return new GetTodosCommand((int?)request.PageNumber, (int?)request.PageSize, this);
    }

    public override GetTodosResponse FromEntity(IEnumerable<Todo> todos)
        => new GetTodosResponse(todos.Select(todo => new { todo.Id, todo.Title, todo.Description, todo.Completed }));
}
