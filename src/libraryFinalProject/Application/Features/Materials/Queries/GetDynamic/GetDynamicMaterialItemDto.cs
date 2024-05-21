using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetDynamic;
public class GetDynamicMaterialItemDto : IDto
{
    public Guid Id { get; set; }
    public string Language { get; set; }
    public string MaterialName { get; set; }
    public List<GetDynamicMaterialPublisherDto> Publishers { get; set; }
    public List<GetDynamicMaterialAuthorDto> Authors { get; set; }
    public List<GetDynamicMaterialCategoryDto> Categories { get; set; }

}
