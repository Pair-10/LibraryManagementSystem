using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Basket: Entity<Guid>
{
    public int ItemQuantity { get; set; } // Sepetin Item Adeti
    public decimal TotalPrice { get; set; } // Sepetin Toplam Fiyatı
    public virtual User User { get; set; } // Bir sepetin  bir kullanıcısı olabilir

    //Bir sepetin birden çok sepetemetaryeli olabilir
    public virtual ICollection<BasketEmeterial> BasketEmeterials { get; set; }   
     
}
