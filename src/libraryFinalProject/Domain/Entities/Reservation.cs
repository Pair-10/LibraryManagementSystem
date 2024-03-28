using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class Reservation : Entity<Guid>
{

    public Guid UserId { get; set; } //
    public Guid MaterialId { get; set; } //

    public string Status { get; set; } // Durumu (onaylandı, bekliyor, iptal edildi)
    //ilişki kısmı
    public virtual User? User { get; set; } = null; //Fk kullanıcı tablosu ilişkisi
    public virtual Material? Material { get; set; } = null;//FK materyal tablosu ilişkisi
    public Reservation()
    {
    }

    public Reservation(Guid userId, Guid materialId, string status)
    {
        UserId = userId;
        MaterialId = materialId;
        Status = status;
    }
}
