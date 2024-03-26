using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BasketEmaterialRepository : EfRepositoryBase<BasketEmaterial, Guid, BaseDbContext>, IBasketEmaterialRepository
{
    public BasketEmaterialRepository(BaseDbContext context) : base(context)
    {
    }
}