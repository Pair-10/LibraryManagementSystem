using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class City : Entity<Guid>
{
    public Guid CountryId { get; set; }//
    public string CityName { get; set; }
    //ilişki kısmı
    public virtual Country? Country { get; set; } = null;//ilişki Fk
    //bir şehrin birden fazla semti(ilçesi) olabilir
    public virtual ICollection<District>? Districts { get; set; } = null;
    public City()
    {
    }

    public City(Guid countryId, string cityName)
    {
        CountryId = countryId;
        CityName = cityName;
    }
}
