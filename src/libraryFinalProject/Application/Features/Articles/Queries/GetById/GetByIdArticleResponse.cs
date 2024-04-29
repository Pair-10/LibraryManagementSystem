using NArchitecture.Core.Application.Responses;

namespace Application.Features.Articles.Queries.GetById;

public class GetByIdArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }
    public string materialId { get; set; }
}