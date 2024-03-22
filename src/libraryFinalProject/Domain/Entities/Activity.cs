using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Activity : Entity<Guid>
{
    public DateTime ActivityDate { get; set; } // Etkinlik tarihi
    public string Desc { get; set; } // Etkinlik açıklaması
    public string Status { get; set; } // Etkinlik durumu
    public string ActivityName { get; set; } // Etkinlik adı
    public string Location { get; set; } // Etkinlik konumu

    //ilişki kısmı
    //bir aktivitenin  birden fazla aktivitebildiriimi olabilir(deger atanmassa null olsun default değeri)
    public virtual ICollection<ActivityNotification>? ActivityNotifications { get; set; } = null;
    //bir aktivitenin  birden fazla kullanıcıaktivitesi olabilir
    public virtual ICollection<UserActivity>? UserActivities { get; set; } = null;

    public Activity()
    {
    }

    public Activity(DateTime activityDate, string desc, string status, string activityName, string location)
    {
        ActivityDate = activityDate;
        Desc = desc;
        Status = status;
        ActivityName = activityName;
        Location = location;
    }
}

