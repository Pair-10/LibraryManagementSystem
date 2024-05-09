using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetDynamic;
public class GetDynamicMaterialPublisherDto : IDto
{
    public Guid PublisherId { get; set; }
    public string PublisherName { get; set; }


}
