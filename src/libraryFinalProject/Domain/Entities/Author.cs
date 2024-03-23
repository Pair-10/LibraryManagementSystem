using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Author : Entity<Guid>
{
    public string Name { get; set; } // Yazarın adı
    public string Surname { get; set; } // Yazarın soyadı
    public string Bio { get; set; } // Yazarın biyografisi
    public string WebSite { get; set; } // Yazarın web sitesi URL'i

    //ilişki kısmı
    // Bir yazarın birden fazla materyali olabilir
    public virtual ICollection<Material>? Materials { get; set; } = null;
    public Author()
    {
    }

    public Author(string name, string surname, string bio, string webSite)
    {
        Name = name;
        Surname = surname;
        Bio = bio;
        WebSite = webSite;
    }
}
