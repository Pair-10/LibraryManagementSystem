using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialTranslatorRepository : EfRepositoryBase<MaterialTranslator, Guid, BaseDbContext>, IMaterialTranslatorRepository
{
    public MaterialTranslatorRepository(BaseDbContext context) : base(context)
    {
    }
}