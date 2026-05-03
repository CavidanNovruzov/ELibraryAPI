using ELibraryAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Abstractions.Repositories;

public interface IRepository<T, TKey> where T : class, IEntity<TKey>
{
    DbSet<T> Table { get; }
}
