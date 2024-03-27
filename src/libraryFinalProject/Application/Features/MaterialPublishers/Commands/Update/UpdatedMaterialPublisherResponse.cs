using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPublishers.Commands.Update;

public class UpdatedMaterialPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }
}