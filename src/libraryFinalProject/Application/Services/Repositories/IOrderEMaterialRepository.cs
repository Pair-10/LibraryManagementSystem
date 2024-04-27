using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderEMaterialRepository : IAsyncRepository<OrderEMaterial, Guid>, IRepository<OrderEMaterial, Guid>
{
}