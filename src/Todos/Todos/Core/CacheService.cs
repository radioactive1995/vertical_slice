
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Todos.Core;

public class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<T?> GetOrAddCache<T>(string key, RequestHandlerDelegate<T> handler, TimeSpan expiry)
    {
        var cachedValue = await cache.GetStringAsync(key);

        if (!string.IsNullOrWhiteSpace(cachedValue))
        {
            return JsonSerializer.Deserialize<T>(cachedValue);
        }

        var result = await handler();

        if (result == null) return default;

        await cache.SetStringAsync(key, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
        {
            SlidingExpiration = expiry,
            AbsoluteExpiration = DateTime.Today.AddDays(1)
        });

        return result;
    }


    public async Task RemoveCache(string[] keys)
    {
        List<Task> arbeid = [];

        foreach (var key in keys)
        {
            arbeid.Add(cache.RemoveAsync(key));
        }

        await Task.WhenAll(arbeid);
    }
}
