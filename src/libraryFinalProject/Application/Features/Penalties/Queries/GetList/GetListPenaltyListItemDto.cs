using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ReturnId { get; set; }
    public decimal PenaltyPrice { get; set; }
    public DateTime PenaltyDate { get; set; }
    public bool PenaltyStatus { get; set; }
}