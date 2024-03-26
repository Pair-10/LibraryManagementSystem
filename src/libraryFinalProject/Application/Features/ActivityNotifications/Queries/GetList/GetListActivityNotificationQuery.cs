using Application.Features.ActivityNotifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ActivityNotifications.Constants.ActivityNotificationsOperationClaims;

namespace Application.Features.ActivityNotifications.Queries.GetList;

public class GetListActivityNotificationQuery : IRequest<GetListResponse<GetListActivityNotificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListActivityNotifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetActivityNotifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListActivityNotificationQueryHandler : IRequestHandler<GetListActivityNotificationQuery, GetListResponse<GetListActivityNotificationListItemDto>>
    {
        private readonly IActivityNotificationRepository _activityNotificationRepository;
        private readonly IMapper _mapper;

        public GetListActivityNotificationQueryHandler(IActivityNotificationRepository activityNotificationRepository, IMapper mapper)
        {
            _activityNotificationRepository = activityNotificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListActivityNotificationListItemDto>> Handle(GetListActivityNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ActivityNotification> activityNotifications = await _activityNotificationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListActivityNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListActivityNotificationListItemDto>>(activityNotifications);
            return response;
        }
    }
}