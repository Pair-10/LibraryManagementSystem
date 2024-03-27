using NArchitecture.Core.Application.Responses;

namespace Application.Features.Invoices.Commands.Update;

public class UpdatedInvoiceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoicePrice { get; set; }
    public string InvoiceType { get; set; }
    public bool Status { get; set; }
}