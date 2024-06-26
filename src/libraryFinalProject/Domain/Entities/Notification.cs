﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Notification : Entity<Guid>
{
   
    public string NotificationDesc { get; set; } // Bildirim açıklaması
    public string NotificationType { get; set; } // Bildirim tipi
    public bool NotificationStatus { get; set; } // Bildirim aktif mi?
    //ilişki kısmı
    //bir bildirimin birden fazla etkinlikbildirimi olabilir
    public virtual ICollection<ActivityNotification>? ActivityNotifications { get; set; }=null;
    public virtual ICollection<UserNotification>? UserNotifications { get; set; } = null;
    public Notification()
    {
    }

    public Notification(string notificationDesc, string notificationType, bool notificationStatus)
    {
        NotificationDesc = notificationDesc;
        NotificationType = notificationType;
        NotificationStatus = notificationStatus;
    }
}
