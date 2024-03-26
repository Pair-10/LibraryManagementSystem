using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Returns.Queries.GetList;

public class GetListReturnListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
}