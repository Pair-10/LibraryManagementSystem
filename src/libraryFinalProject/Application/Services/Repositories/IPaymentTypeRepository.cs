using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPaymentTypeRepository : IAsyncRepository<PaymentType, Guid>, IRepository<PaymentType, Guid>
{
}