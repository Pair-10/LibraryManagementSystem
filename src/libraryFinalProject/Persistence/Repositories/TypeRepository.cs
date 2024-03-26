using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TypeRepository : EfRepositoryBase<Type, Guid, BaseDbContext>, ITypeRepository
{
    public TypeRepository(BaseDbContext context) : base(context)
    {
    }
}