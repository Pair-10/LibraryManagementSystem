using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class MaterialLocation : Entity<Guid>
{
    public Guid LocationId { get; set; }//
    public Guid MaterialId { get; set; }//
    //ilişkı kısmı
    public virtual Location? Location { get; set; } = null;//Fk
    public virtual Material? Material { get; set; } = null;//Fk
    public MaterialLocation()
    {
    }
    public MaterialLocation(Guid locationId, Guid materialId)
    {
        LocationId = locationId;
        MaterialId = materialId;
    }
}
