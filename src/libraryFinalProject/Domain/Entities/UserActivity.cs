using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class UserActivity : Entity<Guid>
{
 
    public Guid UserId { get; set; } //
    public Guid ActivityId { get; set; } //
    public bool ParticipationStatus { get; set; } // Katılım durumu
    public DateTime ParticipationDate { get; set; } // Katılım tarihi
    //ilişki kısmı
    public virtual User? User { get; set; } = null;//ilişki Fk
    public virtual Activity? Activity { get; set; } = null;//ilişki Fk

    public UserActivity()
    {
    }
    public UserActivity(Guid userId, Guid activityId, bool participationStatus, DateTime participationDate)
    {
        UserId = userId;
        ActivityId = activityId;
        ParticipationStatus = participationStatus;
        ParticipationDate = participationDate;
    }
}
