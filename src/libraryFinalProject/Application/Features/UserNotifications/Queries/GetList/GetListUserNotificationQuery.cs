using Application.Features.UserNotifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserNotifications.Constants.UserNotificationsOperationClaims;

namespace Application.Features.UserNotifications.Queries.GetList;

public class GetListUserNotificationQuery : IRequest<GetListResponse<GetListUserNotificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserNotifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserNotifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserNotificationQueryHandler : IRequestHandler<GetListUserNotificationQuery, GetListResponse<GetListUserNotificationListItemDto>>
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IMapper _mapper;

        public GetListUserNotificationQueryHandler(IUserNotificationRepository userNotificationRepository, IMapper mapper)
        {
            _userNotificationRepository = userNotificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserNotificationListItemDto>> Handle(GetListUserNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserNotification> userNotifications = await _userNotificationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListUserNotificationListItemDto>>(userNotifications);
            return response;
        }
    }
}