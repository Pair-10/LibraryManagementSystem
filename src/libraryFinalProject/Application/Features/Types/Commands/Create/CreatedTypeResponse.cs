using NArchitecture.Core.Application.Responses;

namespace Application.Features.Types.Commands.Create;

public class CreatedTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}