using Application.Features.UserActivities.Constants;
using Application.Features.UserActivities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserActivities.Constants.UserActivitiesOperationClaims;

namespace Application.Features.UserActivities.Queries.GetById;

public class GetByIdUserActivityQuery : IRequest<GetByIdUserActivityResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUserActivityQueryHandler : IRequestHandler<GetByIdUserActivityQuery, GetByIdUserActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly UserActivityBusinessRules _userActivityBusinessRules;

        public GetByIdUserActivityQueryHandler(IMapper mapper, IUserActivityRepository userActivityRepository, UserActivityBusinessRules userActivityBusinessRules)
        {
            _mapper = mapper;
            _userActivityRepository = userActivityRepository;
            _userActivityBusinessRules = userActivityBusinessRules;
        }

        public async Task<GetByIdUserActivityResponse> Handle(GetByIdUserActivityQuery request, CancellationToken cancellationToken)
        {
            UserActivity? userActivity = await _userActivityRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userActivityBusinessRules.UserActivityShouldExistWhenSelected(userActivity);

            GetByIdUserActivityResponse response = _mapper.Map<GetByIdUserActivityResponse>(userActivity);
            return response;
        }
    }
}