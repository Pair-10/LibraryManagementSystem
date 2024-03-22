using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class UserSurvey : Entity<Guid>
{
    public Guid UserId { get; set; } //
    public Guid SurveyId { get; set; } // 
    // İlişki kısmı
    public virtual User? User { get; set; } = null;//FK
    public virtual Survey? Survey { get; set; } = null;//FK
    public UserSurvey()
    {
    }
    public UserSurvey(Guid userId, Guid surveyId)
    {
        UserId = userId;
        SurveyId = surveyId;
    }
}
