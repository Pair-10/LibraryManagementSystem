using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdatedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }
}