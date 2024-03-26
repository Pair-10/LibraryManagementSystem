using NArchitecture.Core.Application.Responses;

namespace Application.Features.EmaterialInvoices.Commands.Delete;

public class DeletedEmaterialInvoiceResponse : IResponse
{
    public Guid Id { get; set; }
}