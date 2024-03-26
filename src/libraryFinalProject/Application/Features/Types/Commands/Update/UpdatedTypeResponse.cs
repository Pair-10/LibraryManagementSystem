using NArchitecture.Core.Application.Responses;

namespace Application.Features.Types.Commands.Update;

public class UpdatedTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}