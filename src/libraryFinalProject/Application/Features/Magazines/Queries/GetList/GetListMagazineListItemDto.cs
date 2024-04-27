using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Magazines.Queries.GetList;

public class GetListMagazineListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }
    public string materialId { get; set; }
}