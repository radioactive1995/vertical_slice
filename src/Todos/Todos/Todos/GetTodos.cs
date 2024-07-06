using FastEndpoints;
using MediatR;

namespace Todos.Todos;

public class GetTodosEndpoint(IMediator mediator) : EndpointWithoutRequest<GetTodosResponse[]>
{
    public override void Configure()
    {
        Get("todos");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetTodosQuery();
        var response = await mediator.Send(query);

        await SendOkAsync(response);
    }
}
