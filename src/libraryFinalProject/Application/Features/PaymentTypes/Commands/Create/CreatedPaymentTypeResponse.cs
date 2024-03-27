using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentTypes.Commands.Create;

public class CreatedPaymentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}