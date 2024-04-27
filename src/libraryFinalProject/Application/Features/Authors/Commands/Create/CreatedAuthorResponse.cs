using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Commands.Create;

public class CreatedAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Bio { get; set; }
    public string WebSite { get; set; }
}