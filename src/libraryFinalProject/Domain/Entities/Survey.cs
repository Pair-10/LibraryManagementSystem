using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Survey : Entity<Guid>
{

    public string Title { get; set; } // Anket Başlığı
    public string Description { get; set; } // Anket Açıklaması
    //ilişki kısmı
   //Bir anketin birden çok KullanıcıAnketi olabilir
    public virtual ICollection<UserSurvey>? UserSurveys { get; set; } = null;
    public Survey()
    {
    }
    public Survey(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
