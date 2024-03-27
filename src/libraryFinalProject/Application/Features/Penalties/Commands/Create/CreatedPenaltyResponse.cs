using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Commands.Create;

public class CreatedPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ReturnedId { get; set; }
    public Guid PaymentId { get; set; }
    public decimal PenaltyPrice { get; set; }
    public DateTime PenaltyDate { get; set; }
    public bool PenaltyStatus { get; set; }
}