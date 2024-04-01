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

namespace Application.Features.Activities.Commands.Update;

public class UpdateActivityCommand : IRequest<UpdatedActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public DateTime ActivityDate { get; set; }
    public string Desc { get; set; }
    public bool Status { get; set; }
    public string ActivityName { get; set; }
    public string Location { get; set; }

    public string[] Roles => [Admin, Write, ActivitiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivities"];

    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, UpdatedActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;
        private readonly ActivityBusinessRules _activityBusinessRules;

        public UpdateActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository,
                                         ActivityBusinessRules activityBusinessRules)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _activityBusinessRules = activityBusinessRules;
        }

        public async Task<UpdatedActivityResponse> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            await _activityBusinessRules.ActivityShouldNotExistsWithSameName(request.ActivityName);//bussiines classýndan al
            Activity? activity = await _activityRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _activityBusinessRules.ActivityShouldExistWhenSelected(activity);
            activity = _mapper.Map(request, activity);

            await _activityRepository.UpdateAsync(activity!);

            UpdatedActivityResponse response = _mapper.Map<UpdatedActivityResponse>(activity);
            return response;
        }
    }
}