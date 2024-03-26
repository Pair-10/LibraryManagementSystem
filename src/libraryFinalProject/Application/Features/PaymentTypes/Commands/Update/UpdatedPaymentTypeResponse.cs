using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentTypes.Commands.Update;

public class UpdatedPaymentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}