using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Domain.Entities.Common;

public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid> 
{
}
