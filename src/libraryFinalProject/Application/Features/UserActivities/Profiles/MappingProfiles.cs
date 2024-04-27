using Application.Features.UserActivities.Commands.Create;
using Application.Features.UserActivities.Commands.Delete;
using Application.Features.UserActivities.Commands.Update;
using Application.Features.UserActivities.Queries.GetById;
using Application.Features.UserActivities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserActivities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserActivity, CreateUserActivityCommand>().ReverseMap();
        CreateMap<UserActivity, CreatedUserActivityResponse>().ReverseMap();
        CreateMap<UserActivity, UpdateUserActivityCommand>().ReverseMap();
        CreateMap<UserActivity, UpdatedUserActivityResponse>().ReverseMap();
        CreateMap<UserActivity, DeleteUserActivityCommand>().ReverseMap();
        CreateMap<UserActivity, DeletedUserActivityResponse>().ReverseMap();
        CreateMap<UserActivity, GetByIdUserActivityResponse>().ReverseMap();
        CreateMap<UserActivity, GetListUserActivityListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserActivity>, GetListResponse<GetListUserActivityListItemDto>>().ReverseMap();
    }
}