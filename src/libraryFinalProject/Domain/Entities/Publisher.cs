using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Publisher : Entity<Guid>
{
   
    public string Name { get; set; } // Yayınevi adı
    public string WebSite { get; set; } // Yayınevi web sitesi URL'i
    public string PhoneNumber { get; set; } // Yayınevi telefon numarası
    //ilişki kısmı
    // Bir yayınevinn birden fazla adresii olabilir
    public virtual ICollection<Address>? Addresses { get; set; } = null;//Adres tablosu ilişkisi
    // Bir yayınevinn birden fazla materyali olabilir
    public virtual ICollection<Material>? Materials { get; set; } = null;//materyal tablosu ilişki

    public Publisher()
    {
    }
    public Publisher(string name, string webSite, string phoneNumber)
    {
        Name = name;
        WebSite = webSite;
        PhoneNumber = phoneNumber;
    }
}
