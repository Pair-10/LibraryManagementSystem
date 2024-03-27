using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialAdvices.Queries.GetList;

public class GetListMaterialAdviceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public string Status { get; set; }
    public string MaterialName { get; set; }
}