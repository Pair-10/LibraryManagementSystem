using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialAdviceRepository : EfRepositoryBase<MaterialAdvice, Guid, BaseDbContext>, IMaterialAdviceRepository
{
    public MaterialAdviceRepository(BaseDbContext context) : base(context)
    {
    }
}