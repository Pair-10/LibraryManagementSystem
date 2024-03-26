using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Commands.Update;

public class UpdatedPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WebSite { get; set; }
    public string PhoneNumber { get; set; }
    public Guid AddressId { get; set; }
}