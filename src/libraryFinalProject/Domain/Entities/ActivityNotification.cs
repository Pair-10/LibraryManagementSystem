using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class ActivityNotification : Entity<Guid>
{

    public Guid ActivityId { get; set; }//
    public Guid NotificationId { get; set; } //

    //ilişki kısmı
    public virtual Activity? Activity { get; set; } = null;//ilişki Fk
    public virtual Notification? Notification { get; set; } = null;//ilişki Fk
    public ActivityNotification()
    {
    }

    public ActivityNotification(Guid activityId, Guid notificationId)
    {
        ActivityId = activityId;
        NotificationId = notificationId;
    }
}

