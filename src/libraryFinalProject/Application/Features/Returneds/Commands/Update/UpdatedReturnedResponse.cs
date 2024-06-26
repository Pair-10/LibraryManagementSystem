using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returneds.Commands.Update;

public class UpdatedReturnedResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
}