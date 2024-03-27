using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AdressId { get; set; }
}