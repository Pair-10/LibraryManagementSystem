using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Street : Entity<Guid>
{
    public Guid DistrictId { get; set; } //
    public string StreetName { get; set; }
    //ilişkı kısmı
    public virtual District? District { get; set; } = null;//Fk ilişki
    public virtual ICollection<Address>? Adresses { get; set; } = null; // Bir sokakta birden çok adres olabilir
    public Street()
    {
    }
    public Street(Guid districtId, string streetName)
    {
        DistrictId = districtId;
        StreetName = streetName;
    }
}
