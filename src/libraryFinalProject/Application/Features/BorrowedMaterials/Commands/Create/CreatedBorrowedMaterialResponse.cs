using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreatedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Deadline { get; set; }
}