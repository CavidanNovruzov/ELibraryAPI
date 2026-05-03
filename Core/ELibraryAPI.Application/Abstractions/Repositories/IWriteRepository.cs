using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Application.Abstractions.Repositories;

public interface IWriteRepository<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey>
{
    Task<bool> AddAsync(T model, CancellationToken ct = default);
    Task<bool> AddRangeAsync(IEnumerable<T> datas, CancellationToken ct = default);
    bool Remove(T model);
    Task<bool> RemoveAsync(TKey id, CancellationToken ct = default);
    bool RemoveRange(IEnumerable<T> datas);
    bool Update(T model);
    Task<int> SaveAsync(CancellationToken ct = default);
}
