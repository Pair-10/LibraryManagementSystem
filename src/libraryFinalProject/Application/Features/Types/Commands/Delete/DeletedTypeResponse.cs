using NArchitecture.Core.Application.Responses;

namespace Application.Features.Types.Commands.Delete;

public class DeletedTypeResponse : IResponse
{
    public Guid Id { get; set; }
}