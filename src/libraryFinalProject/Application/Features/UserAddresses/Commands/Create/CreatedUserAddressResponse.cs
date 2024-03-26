using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserAddresses.Commands.Create;

public class CreatedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }
}