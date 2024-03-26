using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ematerials.Commands.Delete;

public class DeletedEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
}