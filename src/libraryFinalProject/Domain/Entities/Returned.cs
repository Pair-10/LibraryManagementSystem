using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Returned : Entity<Guid>
{
    public Guid BorrowedMaterialId { get; set; }
    public bool IsPenalised { get; set; }
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
