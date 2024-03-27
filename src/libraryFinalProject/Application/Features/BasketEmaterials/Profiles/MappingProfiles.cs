using Application.Features.BasketEmaterials.Commands.Create;
using Application.Features.BasketEmaterials.Commands.Delete;
using Application.Features.BasketEmaterials.Commands.Update;
using Application.Features.BasketEmaterials.Queries.GetById;
using Application.Features.BasketEmaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BasketEmaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BasketEmaterial, CreateBasketEmaterialCommand>().ReverseMap();
        CreateMap<BasketEmaterial, CreatedBasketEmaterialResponse>().ReverseMap();
        CreateMap<BasketEmaterial, UpdateBasketEmaterialCommand>().ReverseMap();
        CreateMap<BasketEmaterial, UpdatedBasketEmaterialResponse>().ReverseMap();
        CreateMap<BasketEmaterial, DeleteBasketEmaterialCommand>().ReverseMap();
        CreateMap<BasketEmaterial, DeletedBasketEmaterialResponse>().ReverseMap();
        CreateMap<BasketEmaterial, GetByIdBasketEmaterialResponse>().ReverseMap();
        CreateMap<BasketEmaterial, GetListBasketEmaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<BasketEmaterial>, GetListResponse<GetListBasketEmaterialListItemDto>>().ReverseMap();
    }
}