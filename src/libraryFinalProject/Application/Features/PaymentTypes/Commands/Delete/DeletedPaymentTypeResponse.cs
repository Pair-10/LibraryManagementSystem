using NArchitecture.Core.Application.Responses;

namespace Application.Features.PaymentTypes.Commands.Delete;

public class DeletedPaymentTypeResponse : IResponse
{
    public Guid Id { get; set; }
}