using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialLocations.Commands.Update;

public class UpdatedMaterialLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }
}