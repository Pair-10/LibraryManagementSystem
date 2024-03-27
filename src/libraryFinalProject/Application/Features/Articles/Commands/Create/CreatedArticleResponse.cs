using NArchitecture.Core.Application.Responses;

namespace Application.Features.Articles.Commands.Create;

public class CreatedArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }
}