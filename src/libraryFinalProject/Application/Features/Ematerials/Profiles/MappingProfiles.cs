using Application.Features.Ematerials.Commands.Create;
using Application.Features.Ematerials.Commands.Delete;
using Application.Features.Ematerials.Commands.Update;
using Application.Features.Ematerials.Queries.GetById;
using Application.Features.Ematerials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ematerials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ematerial, CreateEmaterialCommand>().ReverseMap();
        CreateMap<Ematerial, CreatedEmaterialResponse>().ReverseMap();
        CreateMap<Ematerial, UpdateEmaterialCommand>().ReverseMap();
        CreateMap<Ematerial, UpdatedEmaterialResponse>().ReverseMap();
        CreateMap<Ematerial, DeleteEmaterialCommand>().ReverseMap();
        CreateMap<Ematerial, DeletedEmaterialResponse>().ReverseMap();
        CreateMap<Ematerial, GetByIdEmaterialResponse>().ReverseMap();
        CreateMap<Ematerial, GetListEmaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<Ematerial>, GetListResponse<GetListEmaterialListItemDto>>().ReverseMap();
    }
}