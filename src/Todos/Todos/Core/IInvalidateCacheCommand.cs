using MediatR;

namespace Todos.Core;

public interface IInvalidateCacheCommand<TResponse> : IRequest<TResponse>
{
    public string[] InvalidateKeys { get; }
}
