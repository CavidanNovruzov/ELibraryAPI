namespace ELibraryAPI.Domain.Entities.Common;


public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}
