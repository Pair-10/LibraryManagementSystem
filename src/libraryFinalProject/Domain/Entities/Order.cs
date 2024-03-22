using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Order : Entity<Guid>
{
    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
    public virtual Payment? Payment { get; set; } = null; // 1-1 ilişki
    // public virtual Invoice? Invoice { get; set; } =null; // 1-1 ilişki
    // public virtual ICollection<OrderEMaterial>? OrderEMaterials { get; set; } =null; // 1-çok ilişki 

    public Order()
    {

    }

    public Order(decimal totalPrice, Guid userId, bool status)
    {
        TotalPrice = totalPrice;
        UserId = userId;
        Status = status;
    }
}
