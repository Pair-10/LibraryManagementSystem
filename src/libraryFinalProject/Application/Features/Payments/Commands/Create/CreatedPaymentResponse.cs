using NArchitecture.Core.Application.Responses;

namespace Application.Features.Payments.Commands.Create;

public class CreatedPaymentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PaymentTypeId { get; set; }
    public decimal PaymentPrice { get; set; }
    public string Desc { get; set; }
}