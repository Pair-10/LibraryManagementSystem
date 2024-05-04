using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Queries.GetById;

public class GetByIdPenaltyResponse : IResponse
{
    public Guid UserId { get; set; }
    public Guid MaterialID { get; set; }
    public Guid Id { get; set; }
   
    public Guid ReturnedId { get; set; }
   
    public decimal PenaltyPrice { get; set; }
    public int TotalPenaltyDays { get; set; }
    public bool PenaltyStatus { get; set; }
}