using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class MaterialType : Entity<Guid>
{

    public string Name { get; set; } // Tür Adı
    public string Description { get; set; } // Tür Açıklaması
    //ilişkı ksımı
   //Bir Türün birden çok kategoritipi olabilir
    public virtual ICollection<CategoryType>? CategoryTypes { get; set; } = null;
    public MaterialType()
    {
    }

    public MaterialType(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
