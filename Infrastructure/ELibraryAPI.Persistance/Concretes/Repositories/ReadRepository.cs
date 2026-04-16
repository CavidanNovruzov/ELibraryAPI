using ELibraryAPI.Application.Abstractions.Repositories;
using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ELibraryAPI.Persistance.Concrete.Repositories
{
    public class ReadRepository<T, TKey> : IReadRepository<T, TKey> where T : class,IEntity<TKey>
    {
        private readonly ELibraryDbContext _context;
        public ReadRepository(ELibraryDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); 
        public IQueryable<T> GetAll(bool tracking = true, CancellationToken ct = default)
        {
            var query=Table.AsQueryable();
            if(!tracking)
                query=query.AsNoTracking();
            return query;
        }
        
        public async Task<T> GetByIdAsync(TKey id, bool tracking = true, CancellationToken ct = default)
        //=>Table.FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));   
        //=>await Table.FindAsync(Guid.Parse(id));
        {
            var query =Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id.Equals(id),ct);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, CancellationToken ct = default, params Expression<Func<T, object>>[] includes)
        {
            var query= Table.AsQueryable();

            if (includes is { Length: > 0 })
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true, CancellationToken ct = default)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(TKey id, bool tracking = true, CancellationToken ct = default, params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (!tracking)
                query = query.AsNoTracking();

            // Generic TKey müqayisəsi
            return await query.FirstOrDefaultAsync(data => data.Id!.Equals(id));
        }

        public IQueryable<T> GetPaginated(int page, int size, bool tracking = true,CancellationToken ct = default)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query.Skip((page - 1) * size).Take(size);
        }

    }

    public class ReadRepository<T> : ReadRepository<T, Guid>, IReadRepository<T, Guid>
        where T : class, IEntity<Guid>
    {
        public ReadRepository(ELibraryDbContext context) : base(context) { }
    }
}
