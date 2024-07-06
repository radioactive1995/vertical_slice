using FastEndpoints;
using MediatR;

namespace Todos.Todos;

public class AddTodoEndpoint(IMediator mediator) : Endpoint<AddTodoCommand, AddTodoResponse>
{
    public override void Configure()
    {
        Post("todos");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddTodoCommand command, CancellationToken ct)
    {
        var response = await mediator.Send(command);
        await SendOkAsync(response);
    }
}
