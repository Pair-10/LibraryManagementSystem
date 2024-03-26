using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Returned : Entity<Guid>
{
    public Guid BorrowedMaterialId { get; set; }
    public bool IsPenalised { get; set; }
    //İlişki
    public virtual BorrowedMaterial? BorrowedMaterial { get; set; }
    public virtual Penalty? Penalty { get; set; } = null;
    public Returned()
    {
        
    }

    public Returned(Guid borrowedMaterialId, bool isPenalised)
    {
        BorrowedMaterialId = borrowedMaterialId;
        IsPenalised = isPenalised;
    }
}
