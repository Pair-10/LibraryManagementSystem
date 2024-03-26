using Application.Features.ActivityNotifications.Commands.Create;
using Application.Features.ActivityNotifications.Commands.Delete;
using Application.Features.ActivityNotifications.Commands.Update;
using Application.Features.ActivityNotifications.Queries.GetById;
using Application.Features.ActivityNotifications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ActivityNotifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ActivityNotification, CreateActivityNotificationCommand>().ReverseMap();
        CreateMap<ActivityNotification, CreatedActivityNotificationResponse>().ReverseMap();
        CreateMap<ActivityNotification, UpdateActivityNotificationCommand>().ReverseMap();
        CreateMap<ActivityNotification, UpdatedActivityNotificationResponse>().ReverseMap();
        CreateMap<ActivityNotification, DeleteActivityNotificationCommand>().ReverseMap();
        CreateMap<ActivityNotification, DeletedActivityNotificationResponse>().ReverseMap();
        CreateMap<ActivityNotification, GetByIdActivityNotificationResponse>().ReverseMap();
        CreateMap<ActivityNotification, GetListActivityNotificationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ActivityNotification>, GetListResponse<GetListActivityNotificationListItemDto>>().ReverseMap();
    }
}