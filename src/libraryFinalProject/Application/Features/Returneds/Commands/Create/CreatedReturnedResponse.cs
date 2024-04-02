using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returneds.Commands.Create;

public class CreatedReturnedResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public bool IsPenalised { get; set; }
}