using Application.Features.Types.Commands.Create;
using Application.Features.Types.Commands.Delete;
using Application.Features.Types.Commands.Update;
using Application.Features.Types.Queries.GetById;
using Application.Features.Types.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Types.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Type, CreateTypeCommand>().ReverseMap();
        CreateMap<Type, CreatedTypeResponse>().ReverseMap();
        CreateMap<Type, UpdateTypeCommand>().ReverseMap();
        CreateMap<Type, UpdatedTypeResponse>().ReverseMap();
        CreateMap<Type, DeleteTypeCommand>().ReverseMap();
        CreateMap<Type, DeletedTypeResponse>().ReverseMap();
        CreateMap<Type, GetByIdTypeResponse>().ReverseMap();
        CreateMap<Type, GetListTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Type>, GetListResponse<GetListTypeListItemDto>>().ReverseMap();
    }
}