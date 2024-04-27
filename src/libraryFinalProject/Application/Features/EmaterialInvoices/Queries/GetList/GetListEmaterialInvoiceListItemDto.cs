using NArchitecture.Core.Application.Dtos;

namespace Application.Features.EmaterialInvoices.Queries.GetList;

public class GetListEmaterialInvoiceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid InvoiceId { get; set; }
    public int Quantity { get; set; }
    public decimal QuantityPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentType { get; set; }
}