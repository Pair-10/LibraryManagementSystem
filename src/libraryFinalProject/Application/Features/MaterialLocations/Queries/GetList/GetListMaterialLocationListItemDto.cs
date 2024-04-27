using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialLocations.Queries.GetList;

public class GetListMaterialLocationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }
}