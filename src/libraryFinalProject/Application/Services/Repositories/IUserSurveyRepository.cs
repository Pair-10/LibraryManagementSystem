using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserSurveyRepository : IAsyncRepository<UserSurvey, Guid>, IRepository<UserSurvey, Guid>
{
}