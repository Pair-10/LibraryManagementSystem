using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Locations.Queries.GetList;

public class GetListLocationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Section { get; set; }
    public int ShelfNumber { get; set; }
    public int ShelfRow { get; set; }
}