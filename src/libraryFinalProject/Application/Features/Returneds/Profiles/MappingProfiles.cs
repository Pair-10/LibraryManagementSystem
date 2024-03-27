using Application.Features.Returneds.Commands.Create;
using Application.Features.Returneds.Commands.Delete;
using Application.Features.Returneds.Commands.Update;
using Application.Features.Returneds.Queries.GetById;
using Application.Features.Returneds.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Returneds.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Returned, CreateReturnedCommand>().ReverseMap();
        CreateMap<Returned, CreatedReturnedResponse>().ReverseMap();
        CreateMap<Returned, UpdateReturnedCommand>().ReverseMap();
        CreateMap<Returned, UpdatedReturnedResponse>().ReverseMap();
        CreateMap<Returned, DeleteReturnedCommand>().ReverseMap();
        CreateMap<Returned, DeletedReturnedResponse>().ReverseMap();
        CreateMap<Returned, GetByIdReturnedResponse>().ReverseMap();
        CreateMap<Returned, GetListReturnedListItemDto>().ReverseMap();
        CreateMap<IPaginate<Returned>, GetListResponse<GetListReturnedListItemDto>>().ReverseMap();
    }
}