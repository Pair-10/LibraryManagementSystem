using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class MaterialTranslator : Entity<Guid>
{
    public Guid TranslatorId { get; set; } //
     public Guid MaterialId { get; set; } //
    //ilişki kımı
    public virtual Translator? Translator { get; set; } = null; //Fk Translator tablosu ilişkisi
    public virtual Material? Material { get; set; } = null; //Fk materyal tablosu ilişkisi
    public MaterialTranslator()
    {
    }

    public MaterialTranslator(Guid translatorId, Guid materialId)
    {
        TranslatorId = translatorId;
        MaterialId = materialId;
    }
}
