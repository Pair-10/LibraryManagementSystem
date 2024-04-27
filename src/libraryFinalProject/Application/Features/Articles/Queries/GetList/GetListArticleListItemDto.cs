using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Articles.Queries.GetList;

public class GetListArticleListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }
    public string materialId { get; set; }
}