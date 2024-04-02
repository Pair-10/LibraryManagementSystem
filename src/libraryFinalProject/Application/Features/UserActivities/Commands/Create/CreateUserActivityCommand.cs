using Application.Features.UserActivities.Constants;
using Application.Features.UserActivities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.UserActivities.Constants.UserActivitiesOperationClaims;

namespace Application.Features.UserActivities.Commands.Create;

public class CreateUserActivityCommand : IRequest<CreatedUserActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public bool ParticipationStatus { get; set; }
    public DateTime ParticipationDate { get; set; }

    public string[] Roles => [Admin, Write, UserActivitiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserActivities"];

    public class CreateUserActivityCommandHandler : IRequestHandler<CreateUserActivityCommand, CreatedUserActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly UserActivityBusinessRules _userActivityBusinessRules;

        public CreateUserActivityCommandHandler(IMapper mapper, IUserActivityRepository userActivityRepository,
                                         UserActivityBusinessRules userActivityBusinessRules)
        {
            _mapper = mapper;
            _userActivityRepository = userActivityRepository;
            _userActivityBusinessRules = userActivityBusinessRules;
        }

        public async Task<CreatedUserActivityResponse> Handle(CreateUserActivityCommand request, CancellationToken cancellationToken)
        {
            await _userActivityBusinessRules.ActivityIdShouldExistWhenSelected(request.ActivityId, cancellationToken);
            await _userActivityBusinessRules.UserIdShouldExistWhenSelected(request.UserId, cancellationToken);
            UserActivity userActivity = _mapper.Map<UserActivity>(request);

            await _userActivityRepository.AddAsync(userActivity);

            CreatedUserActivityResponse response = _mapper.Map<CreatedUserActivityResponse>(userActivity);
            return response;
        }
    }
}