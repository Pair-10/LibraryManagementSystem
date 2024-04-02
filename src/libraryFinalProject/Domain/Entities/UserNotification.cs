using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserNotification : Entity<Guid>
{
    public Guid UserId { get; set; }//
    public Guid NotificationId { get; set; } //

    //ilişki kısmı
    public virtual User? User { get; set; } = null;//ilişki Fk
    public virtual Notification? Notification { get; set; } = null;//ilişki Fk
    public UserNotification()
    {

    }
    public UserNotification(Guid userId, Guid notificationId)
    {
        UserId = userId;
        NotificationId = notificationId;
    }
}
