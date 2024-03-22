using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Return : Entity<Guid>
{
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
    //İlişki
    public virtual BorrowedMaterial? BorrowedMaterial { get; set; }
    public virtual Penalty? Penalty { get; set; } = null;
    public Return()
    {
        
    }

    public Return(Guid borrowedMaterialId, Guid penaltyId, bool isPenalised)
    {
        BorrowedMaterialId = borrowedMaterialId;
        PenaltyId = penaltyId;
        IsPenalised = isPenalised;
    }
}
