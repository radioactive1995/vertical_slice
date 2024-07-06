using FastEndpoints;
using MediatR;

namespace Todos.Todos;


public class CompleteTodoEndpoint(IMediator mediator) : EndpointWithoutRequest<CompleteTodoResponse>
{
    public override void Configure()
    {
        
        Put("/todos/{id}/complete");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var command = new CompleteTodoCommand(id);
        var result = await mediator.Send(command);
        await SendOkAsync(result);
    }
}
