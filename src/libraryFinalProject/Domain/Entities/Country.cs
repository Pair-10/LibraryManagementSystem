using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Country : Entity<Guid>
{
    public string CountryName { get; set; }
    //bir ülke birden çok şehre sahip olabilir
    public virtual ICollection<City>? Cities { get; set; } = null;
    public Country()
    {
    }

    public Country(string countryName)
    {
        CountryName = countryName;
    }
}
