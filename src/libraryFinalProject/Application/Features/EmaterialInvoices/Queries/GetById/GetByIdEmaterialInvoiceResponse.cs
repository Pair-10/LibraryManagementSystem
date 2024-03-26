using NArchitecture.Core.Application.Responses;

namespace Application.Features.EmaterialInvoices.Queries.GetById;

public class GetByIdEmaterialInvoiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid InvoiceId { get; set; }
    public int Quantity { get; set; }
    public decimal QuantityPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentType { get; set; }
}