using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialAdviceRepository : IAsyncRepository<MaterialAdvice, Guid>, IRepository<MaterialAdvice, Guid>
{
}