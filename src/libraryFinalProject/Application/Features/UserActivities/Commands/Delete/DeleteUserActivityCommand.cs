using Application.Features.UserActivities.Constants;
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

namespace Application.Features.UserActivities.Commands.Delete;

public class DeleteUserActivityCommand : IRequest<DeletedUserActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserActivitiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserActivities"];

    public class DeleteUserActivityCommandHandler : IRequestHandler<DeleteUserActivityCommand, DeletedUserActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly UserActivityBusinessRules _userActivityBusinessRules;

        public DeleteUserActivityCommandHandler(IMapper mapper, IUserActivityRepository userActivityRepository,
                                         UserActivityBusinessRules userActivityBusinessRules)
        {
            _mapper = mapper;
            _userActivityRepository = userActivityRepository;
            _userActivityBusinessRules = userActivityBusinessRules;
        }

        public async Task<DeletedUserActivityResponse> Handle(DeleteUserActivityCommand request, CancellationToken cancellationToken)
        {
            UserActivity? userActivity = await _userActivityRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userActivityBusinessRules.UserActivityShouldExistWhenSelected(userActivity);

            await _userActivityRepository.DeleteAsync(userActivity!);

            DeletedUserActivityResponse response = _mapper.Map<DeletedUserActivityResponse>(userActivity);
            return response;
        }
    }
}