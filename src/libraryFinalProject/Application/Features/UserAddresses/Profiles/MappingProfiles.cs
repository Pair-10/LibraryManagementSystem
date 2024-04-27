using Application.Features.UserAddresses.Commands.Create;
using Application.Features.UserAddresses.Commands.Delete;
using Application.Features.UserAddresses.Commands.Update;
using Application.Features.UserAddresses.Queries.GetById;
using Application.Features.UserAddresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserAddress, CreateUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, CreatedUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, UpdateUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, UpdatedUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, DeleteUserAddressCommand>().ReverseMap();
        CreateMap<UserAddress, DeletedUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, GetByIdUserAddressResponse>().ReverseMap();
        CreateMap<UserAddress, GetListUserAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserAddress>, GetListResponse<GetListUserAddressListItemDto>>().ReverseMap();
    }
}