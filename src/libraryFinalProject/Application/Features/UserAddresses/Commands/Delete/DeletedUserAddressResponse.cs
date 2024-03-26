using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserAddresses.Commands.Delete;

public class DeletedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
}