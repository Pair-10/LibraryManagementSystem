using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Create;

public class CreatedLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Section { get; set; }
    public int ShelfNumber { get; set; }
    public int ShelfRow { get; set; }
}