using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEmaterialInvoiceRepository : IAsyncRepository<EmaterialInvoice, Guid>, IRepository<EmaterialInvoice, Guid>
{
}