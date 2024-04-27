using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPublishers.Commands.Delete;

public class DeletedMaterialPublisherResponse : IResponse
{
    public Guid Id { get; set; }
}