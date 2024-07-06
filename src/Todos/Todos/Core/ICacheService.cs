using MediatR;

namespace Todos.Core;

public interface ICacheService
{
    Task<T?> GetOrAddCache<T>(string key, RequestHandlerDelegate<T> handler, TimeSpan expiry);
    Task RemoveCache(string[] keys);
}
