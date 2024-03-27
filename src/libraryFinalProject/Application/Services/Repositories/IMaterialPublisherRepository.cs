using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialPublisherRepository : IAsyncRepository<MaterialPublisher, Guid>, IRepository<MaterialPublisher, Guid>
{
}