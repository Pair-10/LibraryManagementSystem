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

namespace Application.Features.Activities.Commands.Create;

public class CreateActivityCommand : IRequest<CreatedActivityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public DateTime ActivityDate { get; set; }
    public string Desc { get; set; }
    public bool Status { get; set; }
    public string ActivityName { get; set; }
    public string Location { get; set; }
    public string[] Roles => [Admin, Write, ActivitiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivities"];

    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, CreatedActivityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;
        private readonly ActivityBusinessRules _activityBusinessRules;

        public CreateActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository,
                                         ActivityBusinessRules activityBusinessRules)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _activityBusinessRules = activityBusinessRules;
        }

        public async Task<CreatedActivityResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {   
            await _activityBusinessRules.ActivityShouldNotExistsWithSameName(request.ActivityName);//etkimlik adý kontrolü için bussiness classda ki kuralýna git 
            Activity activity = _mapper.Map<Activity>(request);

            await _activityRepository.AddAsync(activity);

            CreatedActivityResponse response = _mapper.Map<CreatedActivityResponse>(activity);
            return response;
        }
    }
}