using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Category : Entity<Guid>
{
    public string Name { get; set; } // Kategori Adı
    public string Description { get; set; } // Kategori Açıklaması

    //ilişkı ksımı
    //Bir kategorinin birden çok kategoritipi olabilir
    public virtual ICollection<CategoryType>? CategoryTypes { get; set; } = null;
    public virtual ICollection<Book>? Books { get; set; } = null;
    public virtual ICollection<Magazine>? Magazines { get; set; } = null;
    public virtual ICollection<Article>? Articles { get; set; } = null;
    public Category()
    {
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
