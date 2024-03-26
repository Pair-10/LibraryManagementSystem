using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returns.Commands.Update;

public class UpdatedReturnResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
}