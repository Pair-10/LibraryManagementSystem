using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserAddresses.Queries.GetById;

public class GetByIdUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }
}