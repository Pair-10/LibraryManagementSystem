using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returneds.Queries.GetById;

public class GetByIdReturnedResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }
}