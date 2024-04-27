using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Commands.Create;

public class CreatedPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ReturnedId { get; set; }
    public decimal PenaltyPrice { get; set; }
    public int TotalPenaltyDays { get; set; }
    public bool PenaltyStatus { get; set; }
}