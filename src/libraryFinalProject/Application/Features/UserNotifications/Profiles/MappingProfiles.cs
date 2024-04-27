using Application.Features.UserNotifications.Commands.Create;
using Application.Features.UserNotifications.Commands.Delete;
using Application.Features.UserNotifications.Commands.Update;
using Application.Features.UserNotifications.Queries.GetById;
using Application.Features.UserNotifications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserNotifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserNotification, CreateUserNotificationCommand>().ReverseMap();
        CreateMap<UserNotification, CreatedUserNotificationResponse>().ReverseMap();
        CreateMap<UserNotification, UpdateUserNotificationCommand>().ReverseMap();
        CreateMap<UserNotification, UpdatedUserNotificationResponse>().ReverseMap();
        CreateMap<UserNotification, DeleteUserNotificationCommand>().ReverseMap();
        CreateMap<UserNotification, DeletedUserNotificationResponse>().ReverseMap();
        CreateMap<UserNotification, GetByIdUserNotificationResponse>().ReverseMap();
        CreateMap<UserNotification, GetListUserNotificationListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserNotification>, GetListResponse<GetListUserNotificationListItemDto>>().ReverseMap();
    }
}