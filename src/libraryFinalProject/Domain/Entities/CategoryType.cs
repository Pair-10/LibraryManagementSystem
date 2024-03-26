using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class CategoryType : Entity<Guid>
{
    public Guid MaterialId { get; set; }//
    public Guid CategoryId { get; set; } //
    public Guid TypeId { get; set; } //
    //ilişki kısmı
    public virtual Material? Material { get; set; } = null;//ilişki Fk 
    public virtual Category? Category { get; set; } = null;//ilişki Fk    
    public virtual MaterialType? Type { get; set; } = null;//ilişki Fk   
    //Bir kategori türünün birden fazla emateryali olabilir
    public ICollection<Ematerial>? Ematerials { get; set; } = null;
    public CategoryType()
    {
    }
    public CategoryType(Guid materialId, Guid categoryId, Guid typeId)
    {
        MaterialId = materialId;
        CategoryId = categoryId;
        TypeId = typeId;
    }

   
}
