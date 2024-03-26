using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentTypes.Queries.GetById;

public class GetByIdPaymentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}