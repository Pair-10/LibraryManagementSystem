using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialAuthorRepository : IAsyncRepository<MaterialAuthor, Guid>, IRepository<MaterialAuthor, Guid>
{
}