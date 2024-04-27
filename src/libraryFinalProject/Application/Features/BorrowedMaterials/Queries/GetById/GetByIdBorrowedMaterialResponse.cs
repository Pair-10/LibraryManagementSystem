using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Queries.GetById;

public class GetByIdBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Deadline { get; set; }
}