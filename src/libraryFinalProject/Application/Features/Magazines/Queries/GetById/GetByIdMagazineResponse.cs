using NArchitecture.Core.Application.Responses;

namespace Application.Features.Magazines.Queries.GetById;

public class GetByIdMagazineResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }
    public string materialId { get; set; }
}