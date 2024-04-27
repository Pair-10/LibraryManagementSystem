using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialLocations.Commands.Delete;

public class DeletedMaterialLocationResponse : IResponse
{
    public Guid Id { get; set; }
}