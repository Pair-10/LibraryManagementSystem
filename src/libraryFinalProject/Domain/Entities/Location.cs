using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Location : Entity<Guid>
{
  
    public string Section { get; set; } // Bölüm

    public int ShelfNumber { get; set; } // Raf Numarası
    public int ShelfRow { get; set; } // Raf Sırası
    public int ShelfRowPageCapacity { get; set; } = 1000;

    // ilişki kısmı
    //Bir konumun birden çok materyalkonumu olabilir
    public virtual ICollection<MaterialLocation>? MaterialLocations { get; set; } = null;
    public Location()
    {
    }

    public Location(string section, int shelfNumber, int shelfRow, int shelfRowPageCapacity)
    {
        Section = section;
        ShelfNumber = shelfNumber;
        ShelfRow = shelfRow;
        ShelfRowPageCapacity = shelfRowPageCapacity;
    }
}
