using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmaterialInvoiceRepository : EfRepositoryBase<EmaterialInvoice, Guid, BaseDbContext>, IEmaterialInvoiceRepository
{
    public EmaterialInvoiceRepository(BaseDbContext context) : base(context)
    {
    }
}