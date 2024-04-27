using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialAuthors.Queries.GetList;

public class GetListMaterialAuthorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }
}