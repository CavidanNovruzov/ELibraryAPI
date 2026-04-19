using ELibraryAPI.Domain.Entities.Common;

using System.Linq.Expressions;
using System.Text;

namespace ELibraryAPI.Application.Abstractions.Repositories;

public interface IReadRepository<T, TKey> : IRepository<T, TKey> where T : class,IEntity<TKey>
{
    IQueryable<T> GetAll(bool tracking=true,CancellationToken ct=default); 
    IQueryable<T> GetWhere(Expression<Func<T,bool>>method, bool tracking = true, CancellationToken ct = default);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, CancellationToken ct = default, params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdAsync(TKey id, bool tracking = true, CancellationToken ct = default, params Expression<Func<T, object>>[] includes);
    IQueryable<T> GetPaginated(int page, int size, bool tracking = true, CancellationToken ct = default);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool tracking = true, CancellationToken ct = default);
}
