using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BorrowedMaterials.Queries.GetList;

public class GetListBorrowedMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public bool IsReturned { get; set; }
    public DateTime Deadline { get; set; }
}