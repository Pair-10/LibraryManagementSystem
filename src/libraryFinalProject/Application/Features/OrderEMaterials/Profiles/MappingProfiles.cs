using Application.Features.OrderEMaterials.Commands.Create;
using Application.Features.OrderEMaterials.Commands.Delete;
using Application.Features.OrderEMaterials.Commands.Update;
using Application.Features.OrderEMaterials.Queries.GetById;
using Application.Features.OrderEMaterials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderEMaterials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrderEMaterial, CreateOrderEMaterialCommand>().ReverseMap();
        CreateMap<OrderEMaterial, CreatedOrderEMaterialResponse>().ReverseMap();
        CreateMap<OrderEMaterial, UpdateOrderEMaterialCommand>().ReverseMap();
        CreateMap<OrderEMaterial, UpdatedOrderEMaterialResponse>().ReverseMap();
        CreateMap<OrderEMaterial, DeleteOrderEMaterialCommand>().ReverseMap();
        CreateMap<OrderEMaterial, DeletedOrderEMaterialResponse>().ReverseMap();
        CreateMap<OrderEMaterial, GetByIdOrderEMaterialResponse>().ReverseMap();
        CreateMap<OrderEMaterial, GetListOrderEMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<OrderEMaterial>, GetListResponse<GetListOrderEMaterialListItemDto>>().ReverseMap();
    }
}