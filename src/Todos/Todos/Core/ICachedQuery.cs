using MediatR;

namespace Todos.Core;

public interface ICachedQuery<TResponse> : IRequest<TResponse>
{
    public string Key { get; }
}
