using NArchitecture.Core.Application.Responses;

namespace Application.Features.Publishers.Queries.GetById;

public class GetByIdPublisherResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WebSite { get; set; }
    public string PhoneNumber { get; set; }
    public Guid AddressId { get; set; }
}