using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ReturnedId { get; set; }
    public Guid UserId { get; set; }
    public Guid MaterialID { get; set; }
    public decimal PenaltyPrice { get; set; }
    public int TotalPenaltyDays { get; set; }
    public bool PenaltyStatus { get; set; }
}