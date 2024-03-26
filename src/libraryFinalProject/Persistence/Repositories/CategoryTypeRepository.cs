using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryTypeRepository : EfRepositoryBase<CategoryType, Guid, BaseDbContext>, ICategoryTypeRepository
{
    public CategoryTypeRepository(BaseDbContext context) : base(context)
    {
    }
}