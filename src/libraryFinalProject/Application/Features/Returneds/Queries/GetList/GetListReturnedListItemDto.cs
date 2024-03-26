using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Returneds.Queries.GetList;

public class GetListReturnedListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
}