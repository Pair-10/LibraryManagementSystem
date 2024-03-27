using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPublishers.Commands.Create;

public class CreatedMaterialPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }
}