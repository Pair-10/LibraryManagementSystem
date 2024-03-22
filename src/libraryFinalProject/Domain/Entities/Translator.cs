using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Translator : Entity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Bio { get; set; }
    public string Website { get; set; }
    //ilişkı kısmı
    //bir çevirmenin  birden fazla materyalçevirisi olabilir olabilir
    public virtual ICollection<MaterialTranslator>? MaterialTranslators { get; set; } = null;
    public Translator()
    {
    }
    public Translator(string name, string surname, string bio, string website)
    {
        Name = name;
        Surname = surname;
        Bio = bio;
        Website = website;
    }
}

