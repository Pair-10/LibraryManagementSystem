using Application.Features.Magazines.Commands.Create;
using Application.Features.Magazines.Commands.Delete;
using Application.Features.Magazines.Commands.Update;
using Application.Features.Magazines.Queries.GetById;
using Application.Features.Magazines.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Magazines.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Magazine, CreateMagazineCommand>().ReverseMap();
        CreateMap<Magazine, CreatedMagazineResponse>().ReverseMap();
        CreateMap<Magazine, UpdateMagazineCommand>().ReverseMap();
        CreateMap<Magazine, UpdatedMagazineResponse>().ReverseMap();
        CreateMap<Magazine, DeleteMagazineCommand>().ReverseMap();
        CreateMap<Magazine, DeletedMagazineResponse>().ReverseMap();
        CreateMap<Magazine, GetByIdMagazineResponse>().ReverseMap();
        CreateMap<Magazine, GetListMagazineListItemDto>().ReverseMap();
        CreateMap<IPaginate<Magazine>, GetListResponse<GetListMagazineListItemDto>>().ReverseMap();
    }
}