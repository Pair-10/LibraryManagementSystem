using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class BorrowedMaterial : Entity<Guid>
{
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Deadline { get; set; }//Son geri getirme tarihi.
    //İlişki
    public virtual Material? Material { get; set; } = null;//FK
    public virtual User? User { get; set; } = null;//FK
    public virtual ICollection<Returned>? Returneds { get; set; } = null;
    public BorrowedMaterial()
    {

    }
    public BorrowedMaterial(Guid materialId, Guid userId, DateTime deadline)
    {
        MaterialId = materialId;
        UserId = userId;
        Deadline = deadline;
    }
}
