using Application.Features.Activities.Constants;
using Application.Features.Activities.Constants;
using Application.Features.Activities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Activities.Constants.ActivitiesOperationClaims;

namespace Application.Features.Activities.Commands.Delete;

public class DeleteActivityCommand : IRequest<DeletedActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ActivitiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivities"];

    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, DeletedActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;
        private readonly ActivityBusinessRules _activityBusinessRules;

        public DeleteActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository,
                                         ActivityBusinessRules activityBusinessRules)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _activityBusinessRules = activityBusinessRules;
        }

        public async Task<DeletedActivityResponse> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            Activity? activity = await _activityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _activityBusinessRules.ActivityShouldExistWhenSelected(activity);

            await _activityRepository.DeleteAsync(activity!);

            DeletedActivityResponse response = _mapper.Map<DeletedActivityResponse>(activity);
            return response;
        }
    }
}