using Application.Features.MaterialLocations.Commands.Create;
using Application.Features.MaterialLocations.Commands.Delete;
using Application.Features.MaterialLocations.Commands.Update;
using Application.Features.MaterialLocations.Queries.GetById;
using Application.Features.MaterialLocations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialLocations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialLocation, CreateMaterialLocationCommand>().ReverseMap();
        CreateMap<MaterialLocation, CreatedMaterialLocationResponse>().ReverseMap();
        CreateMap<MaterialLocation, UpdateMaterialLocationCommand>().ReverseMap();
        CreateMap<MaterialLocation, UpdatedMaterialLocationResponse>().ReverseMap();
        CreateMap<MaterialLocation, DeleteMaterialLocationCommand>().ReverseMap();
        CreateMap<MaterialLocation, DeletedMaterialLocationResponse>().ReverseMap();
        CreateMap<MaterialLocation, GetByIdMaterialLocationResponse>().ReverseMap();
        CreateMap<MaterialLocation, GetListMaterialLocationListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialLocation>, GetListResponse<GetListMaterialLocationListItemDto>>().ReverseMap();
    }
}