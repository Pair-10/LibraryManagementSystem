using Application.Features.Activities.Commands.Create;
using Application.Features.Activities.Commands.Delete;
using Application.Features.Activities.Commands.Update;
using Application.Features.Activities.Queries.GetById;
using Application.Features.Activities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Activities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, CreateActivityCommand>().ReverseMap();
        CreateMap<Activity, CreatedActivityResponse>().ReverseMap();
        CreateMap<Activity, UpdateActivityCommand>().ReverseMap();
        CreateMap<Activity, UpdatedActivityResponse>().ReverseMap();
        CreateMap<Activity, DeleteActivityCommand>().ReverseMap();
        CreateMap<Activity, DeletedActivityResponse>().ReverseMap();
        CreateMap<Activity, GetByIdActivityResponse>().ReverseMap();
        CreateMap<Activity, GetListActivityListItemDto>().ReverseMap();
        CreateMap<IPaginate<Activity>, GetListResponse<GetListActivityListItemDto>>().ReverseMap();
    }
}