using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialTypes.Queries.GetList;

public class GetListMaterialTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}