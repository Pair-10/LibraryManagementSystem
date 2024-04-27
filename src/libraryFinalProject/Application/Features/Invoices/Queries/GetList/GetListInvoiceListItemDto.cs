using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Invoices.Queries.GetList;

public class GetListInvoiceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoicePrice { get; set; }
    public string InvoiceType { get; set; }
    public bool Status { get; set; }
}