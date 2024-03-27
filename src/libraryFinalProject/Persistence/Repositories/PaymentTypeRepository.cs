using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PaymentTypeRepository : EfRepositoryBase<PaymentType, Guid, BaseDbContext>, IPaymentTypeRepository
{
    public PaymentTypeRepository(BaseDbContext context) : base(context)
    {
    }
}