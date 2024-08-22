namespace CleanArchitecture.Infrastructure.Caching;

using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Application.Contracts.Infrastructure.Caching;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    private readonly IDistributedCache _distributedCache = distributedCache;
    private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();

    public async Task<T?> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
        where T : class
    {
        var cachedValue = await _distributedCache.GetStringAsync(cacheKey, cancellationToken);
        if (cachedValue is null)
        {
            return default(T?);
        }
        T? result = JsonConvert.DeserializeObject<T>(cachedValue);
        return result;
    }

    public async Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(cacheKey, cancellationToken);
        CacheKeys.TryRemove(cacheKey, out bool _);
    }

    public Task RemoveByPrefixAsync(string cacheKey, CancellationToken cancellationToken = default)
    {
        var tasks = CacheKeys.Keys.Where(k => k.StartsWith(cacheKey))
            .Select(k => RemoveAsync(k, cancellationToken));
        return Task.WhenAll(tasks);
    }

    public async Task SetAsync<T>(string cacheKey, T value, CancellationToken cancellationToken = default)
    {
        string cachedValue = JsonConvert.SerializeObject(value, Formatting.Indented);
        await _distributedCache.SetStringAsync(cacheKey, cachedValue, cancellationToken);
        CacheKeys.TryAdd(cacheKey, true);
    }
}
