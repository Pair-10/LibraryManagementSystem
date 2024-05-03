using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public bool IsReturned { get; set; }
    public DateTime Deadline { get; set; }

}