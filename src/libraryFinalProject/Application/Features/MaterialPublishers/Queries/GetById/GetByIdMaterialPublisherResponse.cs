using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPublishers.Queries.GetById;

public class GetByIdMaterialPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }
}