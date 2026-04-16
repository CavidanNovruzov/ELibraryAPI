using ELibraryAPI.Application.Abstractions.Repositories;
using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ELibraryAPI.Persistance.Concrete.Repositories;

public class WriteRepository<T, TKey> : IWriteRepository<T, TKey> where T : class, IEntity<TKey>
{
    private readonly ELibraryDbContext _context;

    public WriteRepository(ELibraryDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model, CancellationToken ct = default)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model, ct);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> datas, CancellationToken ct = default)
    {
        await Table.AddRangeAsync(datas, ct);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveAsync(TKey id, CancellationToken ct = default)
    {
        T? model = await Table.FirstOrDefaultAsync(data => data.Id!.Equals(id), ct);

        if (model != null)
        {
            return Remove(model);
        }

        return false;
    }

    public bool RemoveRange(IEnumerable<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }

    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync(CancellationToken ct = default)
    => await _context.SaveChangesAsync(ct);
}

public class WriteRepository<T> : WriteRepository<T, Guid>, IWriteRepository<T, Guid>
    where T : class, IEntity<Guid>
{
    public WriteRepository(ELibraryDbContext context) : base(context) { }
}