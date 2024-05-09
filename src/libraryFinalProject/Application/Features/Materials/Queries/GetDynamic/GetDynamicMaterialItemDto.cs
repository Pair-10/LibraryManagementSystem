using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetDynamic;
public class GetDynamicMaterialItemDto : IDto
{
    public Guid Id { get; set; }
    public string Language { get; set; }
    public string MaterialName { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public Guid PublisherId { get; set; }
    public string PublisherName { get; set; }
    public Guid TranslatorId { get; set; }
    public string TranslatorName { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }

}
