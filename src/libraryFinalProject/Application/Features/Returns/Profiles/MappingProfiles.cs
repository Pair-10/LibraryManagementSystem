using Application.Features.Returns.Commands.Create;
using Application.Features.Returns.Commands.Delete;
using Application.Features.Returns.Commands.Update;
using Application.Features.Returns.Queries.GetById;
using Application.Features.Returns.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Returns.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Return, CreateReturnCommand>().ReverseMap();
        CreateMap<Return, CreatedReturnResponse>().ReverseMap();
        CreateMap<Return, UpdateReturnCommand>().ReverseMap();
        CreateMap<Return, UpdatedReturnResponse>().ReverseMap();
        CreateMap<Return, DeleteReturnCommand>().ReverseMap();
        CreateMap<Return, DeletedReturnResponse>().ReverseMap();
        CreateMap<Return, GetByIdReturnResponse>().ReverseMap();
        CreateMap<Return, GetListReturnListItemDto>().ReverseMap();
        CreateMap<IPaginate<Return>, GetListResponse<GetListReturnListItemDto>>().ReverseMap();
    }
}