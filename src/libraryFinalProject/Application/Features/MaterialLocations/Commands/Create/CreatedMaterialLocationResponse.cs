using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialLocations.Commands.Create;

public class CreatedMaterialLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }
}