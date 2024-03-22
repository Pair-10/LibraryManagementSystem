using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BorrowedMaterial : Entity<Guid>
{
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Deadline { get; set; }//Son geri getirme tarihi.
    //İlişki
    public virtual Material? Material { get; set; }//FK
    public virtual User? User { get; set; }//FK
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
