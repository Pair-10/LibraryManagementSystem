using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class MaterialAdvice : Entity<Guid>
{  //MateryalÖnerileri 
    public Guid UserId { get; set; }//
    public string AuthorName { get; set; }//yazarIsmi
    public string Status { get; set; } //Durum
    public string MaterialName { get; set; } //MetaryalAdı

    //ilişki kısmı
    public virtual User? User { get; set; } = null;//ilişki Fk

    public MaterialAdvice()
    {
    }

    public MaterialAdvice(Guid userId, string authorName, string status, string materialName)
    {
        UserId = userId;
        AuthorName = authorName;
        Status = status;
        MaterialName = materialName;
    }
}
