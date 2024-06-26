using Application.Features.ActivityNotifications.Constants;
using Application.Features.ActivityNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ActivityNotifications.Constants.ActivityNotificationsOperationClaims;
using Application.Features.BasketEmaterials.Rules;

namespace Application.Features.ActivityNotifications.Commands.Create;

public class CreateActivityNotificationCommand : IRequest<CreatedActivityNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ActivityId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, ActivityNotificationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivityNotifications"];

    public class CreateActivityNotificationCommandHandler : IRequestHandler<CreateActivityNotificationCommand, CreatedActivityNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityNotificationRepository _activityNotificationRepository;
        private readonly ActivityNotificationBusinessRules _activityNotificationBusinessRules;

        public CreateActivityNotificationCommandHandler(IMapper mapper, IActivityNotificationRepository activityNotificationRepository,
                                         ActivityNotificationBusinessRules activityNotificationBusinessRules)
        {
            _mapper = mapper;
            _activityNotificationRepository = activityNotificationRepository;
            _activityNotificationBusinessRules = activityNotificationBusinessRules;
        }

        public async Task<CreatedActivityNotificationResponse> Handle(CreateActivityNotificationCommand request, CancellationToken cancellationToken)
        {
            await _activityNotificationBusinessRules.ActivityIdShouldExist(request.ActivityId);//bussiines classından al
            await _activityNotificationBusinessRules.NotificationIdShouldExist(request.NotificationId);//bussiines classından al
            ActivityNotification activityNotification = _mapper.Map<ActivityNotification>(request);

            await _activityNotificationRepository.AddAsync(activityNotification);

            CreatedActivityNotificationResponse response = _mapper.Map<CreatedActivityNotificationResponse>(activityNotification);
            return response;
        }
    }
}