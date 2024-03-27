using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaterialPublisher : Entity<Guid>
{
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }
    //İlişki
    public virtual Material? Material { get; set; }
    public virtual Publisher? Publisher { get; set; }

    public MaterialPublisher()
    {
    }

    public MaterialPublisher(Guid materialId, Guid puslisherId)
    {
        MaterialId = materialId;
        PuslisherId = puslisherId;
    }
}
