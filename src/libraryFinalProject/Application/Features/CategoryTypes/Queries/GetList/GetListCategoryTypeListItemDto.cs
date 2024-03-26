using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CategoryTypes.Queries.GetList;

public class GetListCategoryTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TypeId { get; set; }
}