using NArchitecture.Core.Application.Responses;

namespace Application.Features.Invoices.Commands.Create;

public class CreatedInvoiceResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoicePrice { get; set; }
    public string InvoiceType { get; set; }
    public bool Status { get; set; }
}