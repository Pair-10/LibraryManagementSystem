using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaterialAuthorRepository : EfRepositoryBase<MaterialAuthor, Guid, BaseDbContext>, IMaterialAuthorRepository
{
    public MaterialAuthorRepository(BaseDbContext context) : base(context)
    {
    }
}