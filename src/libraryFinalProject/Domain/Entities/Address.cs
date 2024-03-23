using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Address : Entity<Guid>
{
    public Guid UserId { get; set; } //
    public Guid StreetId { get; set; } //
    public Guid PublisherId { get; set; } //

    //bir adresin hangi kullanıcıya ait olduğunu belirtmek için 
    public virtual User? User { get; set; } = null;//Fk
    public virtual Street? Street { get; set; } = null;//Fk
    public virtual Publisher? Publisher { get; set; } = null;//Fk

    public Address()
    {
    }

    public Address(Guid userId, Guid streetId, Guid publisherId)
    {
        UserId = userId;
        StreetId = streetId;
        PublisherId = publisherId;
    }
}
