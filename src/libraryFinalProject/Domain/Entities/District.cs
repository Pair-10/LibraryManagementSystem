using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class District : Entity<Guid>
{
    public Guid CityId { get; set; } //
    public string DistrictName { get; set; }
    //ililki ksımı
    public virtual City? City { get; set; } = null;//ilişki Fk                
    public virtual ICollection<Street>? Streets { get; set; } = null; // Bir ilçenin birden çok sokağı olabilir
    public District()
    {
    }
    public District(Guid cityId, string districtName)
    {
        CityId = cityId;
        DistrictName = districtName;
    }
}
