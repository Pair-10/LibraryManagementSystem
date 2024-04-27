using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserAddress : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }
    //İlişki
    public virtual User? User { get; set; } = null;
    public virtual Address? Address { get; set; } = null;
    public UserAddress()
    {
    }

    public UserAddress(Guid userId, Guid adressId)
    {
        UserId = userId;
        AdressId = adressId;
    }
}
