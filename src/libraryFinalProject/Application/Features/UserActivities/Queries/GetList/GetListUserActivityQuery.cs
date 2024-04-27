using Application.Features.UserActivities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserActivities.Constants.UserActivitiesOperationClaims;

namespace Application.Features.UserActivities.Queries.GetList;

public class GetListUserActivityQuery : IRequest<GetListResponse<GetListUserActivityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserActivities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserActivities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserActivityQueryHandler : IRequestHandler<GetListUserActivityQuery, GetListResponse<GetListUserActivityListItemDto>>
    {
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IMapper _mapper;

        public GetListUserActivityQueryHandler(IUserActivityRepository userActivityRepository, IMapper mapper)
        {
            _userActivityRepository = userActivityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserActivityListItemDto>> Handle(GetListUserActivityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserActivity> userActivities = await _userActivityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserActivityListItemDto> response = _mapper.Map<GetListResponse<GetListUserActivityListItemDto>>(userActivities);
            return response;
        }
    }
}