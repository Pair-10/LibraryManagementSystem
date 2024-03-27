using NArchitecture.Core.Application.Responses;

namespace Application.Features.Streets.Queries.GetById;

public class GetByIdStreetResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string StreetName { get; set; }
}