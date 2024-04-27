using NArchitecture.Core.Application.Responses;

namespace Application.Features.Payments.Queries.GetById;

public class GetByIdPaymentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public Guid PaymentTypeId { get; set; }
    public decimal PaymentPrice { get; set; }
    public string Desc { get; set; }
}