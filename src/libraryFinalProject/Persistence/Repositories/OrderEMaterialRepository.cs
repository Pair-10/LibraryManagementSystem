using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderEMaterialRepository : EfRepositoryBase<OrderEMaterial, Guid, BaseDbContext>, IOrderEMaterialRepository
{
    public OrderEMaterialRepository(BaseDbContext context) : base(context)
    {
    }
}