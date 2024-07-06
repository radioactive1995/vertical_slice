using MediatR;

namespace Todos.Core;


public class InvalidateCacheCommandHandlerPipelineBehavior<TRequest, TResponse>(
    ICacheService cacheService) : IPipelineBehavior<TRequest, TResponse?>
    where TRequest : IInvalidateCacheCommand<TResponse>
{
    public async Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse?> next, CancellationToken cancellationToken)
    {
        await cacheService.RemoveCache(request.InvalidateKeys);

        var response = await next();

        return response;
    }
}
