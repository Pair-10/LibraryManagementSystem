using Application.Features.UserActivities.Constants;
using Application.Features.UserActivities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserActivities.Constants.UserActivitiesOperationClaims;

namespace Application.Features.UserActivities.Commands.Update;

public class UpdateUserActivityCommand : IRequest<UpdatedUserActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ActivityId { get; set; }
    public bool ParticipationStatus { get; set; }
    public DateTime ParticipationDate { get; set; }

    public string[] Roles => [Admin, Write, UserActivitiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserActivities"];

    public class UpdateUserActivityCommandHandler : IRequestHandler<UpdateUserActivityCommand, UpdatedUserActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly UserActivityBusinessRules _userActivityBusinessRules;

        public UpdateUserActivityCommandHandler(IMapper mapper, IUserActivityRepository userActivityRepository,
                                         UserActivityBusinessRules userActivityBusinessRules)
        {
            _mapper = mapper;
            _userActivityRepository = userActivityRepository;
            _userActivityBusinessRules = userActivityBusinessRules;
        }

        public async Task<UpdatedUserActivityResponse> Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
        {
            UserActivity? userActivity = await _userActivityRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userActivityBusinessRules.UserActivityShouldExistWhenSelected(userActivity);
            userActivity = _mapper.Map(request, userActivity);

            await _userActivityRepository.UpdateAsync(userActivity!);

            UpdatedUserActivityResponse response = _mapper.Map<UpdatedUserActivityResponse>(userActivity);
            return response;
        }
    }
}