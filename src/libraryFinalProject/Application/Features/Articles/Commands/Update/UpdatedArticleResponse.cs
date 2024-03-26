using NArchitecture.Core.Application.Responses;

namespace Application.Features.Articles.Commands.Update;

public class UpdatedArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }
}