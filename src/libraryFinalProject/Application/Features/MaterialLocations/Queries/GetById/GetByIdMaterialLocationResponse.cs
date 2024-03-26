using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialLocations.Queries.GetById;

public class GetByIdMaterialLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }
}