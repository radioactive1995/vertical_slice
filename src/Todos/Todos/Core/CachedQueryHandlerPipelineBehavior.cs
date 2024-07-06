using MediatR;

namespace Todos.Core;

public class CachedQueryHandlerPipelineBehavior<TRequest, TResponse>(
    ICacheService cacheService) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery<TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = cacheService.GetOrAddCache(request.Key, handler: next, expiry: TimeSpan.FromMinutes(5));
        return result!;
    }
}
