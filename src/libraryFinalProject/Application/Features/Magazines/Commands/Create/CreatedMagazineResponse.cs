using NArchitecture.Core.Application.Responses;

namespace Application.Features.Magazines.Commands.Create;

public class CreatedMagazineResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }
}