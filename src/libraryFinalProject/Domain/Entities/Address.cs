using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Address : Entity<Guid>
{
    public Guid StreetId { get; set; } //

    //bir adresin hangi kullanıcıya ait olduğunu belirtmek için 
    public virtual Street? Street { get; set; } = null;//Fk
    public virtual ICollection<UserAddress>? UserAddresses { get; set; } = null;
    public virtual ICollection<Publisher>? Publishers { get; set; } = null;
    public Address()
    {
    }

    public Address(Guid streetId)
    {
        StreetId = streetId;
    }
}
