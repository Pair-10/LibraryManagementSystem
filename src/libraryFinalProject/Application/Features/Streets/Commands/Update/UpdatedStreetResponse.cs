using NArchitecture.Core.Application.Responses;

namespace Application.Features.Streets.Commands.Update;

public class UpdatedStreetResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string StreetName { get; set; }
}