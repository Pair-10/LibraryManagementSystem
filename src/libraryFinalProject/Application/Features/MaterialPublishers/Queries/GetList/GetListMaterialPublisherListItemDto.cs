using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialPublishers.Queries.GetList;

public class GetListMaterialPublisherListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }
}