using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BasketEmaterial : Entity<Guid>
{
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; } // Sepetin Toplam Fiyatı
    public int Quantity { get; set; } // Sepetin Toplam Fiyatı

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual Ematerial? Ematerial { get; set; } = null;

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual Basket? Basket { get; set; } = null;

    public BasketEmaterial()
    {
    }

    public BasketEmaterial(Guid ematerialId, Guid basketId, decimal totalPrice, int quantity)
    {
        EmaterialId = ematerialId;
        BasketId = basketId;
        TotalPrice = totalPrice;
        Quantity = quantity;
    }
}
