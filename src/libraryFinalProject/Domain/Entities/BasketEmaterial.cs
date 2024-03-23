using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BasketEmaterial : Entity<Guid>
{
    public Guid EmeterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; } // Sepetin Toplam Fiyatı
    public int Quantity { get; set; } // Sepetin Toplam Fiyatı

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual Ematerial Ematerial { get; set; }

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual Basket Basket { get; set; }



}
