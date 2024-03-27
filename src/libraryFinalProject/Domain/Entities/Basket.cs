using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Basket : Entity<Guid>
{
    public Guid UserId { get; set; }
    public int ItemQuantity { get; set; } // Sepetin Item Adeti
    public decimal TotalPrice { get; set; } // Sepetin Toplam Fiyatı
    public virtual User? User { get; set; } = null; // Bir sepetin  bir kullanıcısı olabilir

    //Bir sepetin birden çok sepetemetaryeli olabilir
    public virtual ICollection<BasketEmaterial>? BasketEmeterials { get; set; } = null;

    public Basket()
    {
    }

    public Basket(Guid userId, int ıtemQuantity, decimal totalPrice)
    {
        UserId = userId;
        ItemQuantity = ıtemQuantity;
        TotalPrice = totalPrice;
    }
}
