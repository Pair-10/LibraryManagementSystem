using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaterialTranslatorRepository : IAsyncRepository<MaterialTranslator, Guid>, IRepository<MaterialTranslator, Guid>
{
}