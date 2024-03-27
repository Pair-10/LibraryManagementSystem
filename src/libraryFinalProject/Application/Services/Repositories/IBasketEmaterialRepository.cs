using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBasketEmaterialRepository : IAsyncRepository<BasketEmaterial, Guid>, IRepository<BasketEmaterial, Guid>
{
}