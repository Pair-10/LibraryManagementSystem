using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Types.Queries.GetList;

public class GetListTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}