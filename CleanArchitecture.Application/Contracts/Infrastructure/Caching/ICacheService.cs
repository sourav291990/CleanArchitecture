namespace CleanArchitecture.Application.Contracts.Infrastructure.Caching;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default) where T: class;
    Task SetAsync<T>(string cacheKey, T value, CancellationToken cancellationToken = default);
    Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default);
    Task RemoveByPrefixAsync(string cacheKey, CancellationToken cancellationToken = default);
}
