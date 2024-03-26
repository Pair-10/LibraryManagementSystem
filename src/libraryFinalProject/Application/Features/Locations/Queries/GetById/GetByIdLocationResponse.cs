using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Queries.GetById;

public class GetByIdLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Section { get; set; }
    public int ShelfNumber { get; set; }
    public int ShelfRow { get; set; }
}