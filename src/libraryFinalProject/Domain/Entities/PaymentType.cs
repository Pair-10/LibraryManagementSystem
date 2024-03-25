using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PaymentType : Entity<Guid>
{
    public bool Type {  get; set; }

    //İlişki
    public virtual ICollection<Payment>? Payments { get;} = null;

    public PaymentType()
    {
    }

    public PaymentType(bool type)
    {
        Type = type;
    }
}
