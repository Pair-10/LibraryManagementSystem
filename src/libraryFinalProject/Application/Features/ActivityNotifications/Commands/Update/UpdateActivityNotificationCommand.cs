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

namespace Application.Features.ActivityNotifications.Commands.Update;

public class UpdateActivityNotificationCommand : IRequest<UpdatedActivityNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ActivityId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, ActivityNotificationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivityNotifications"];

    public class UpdateActivityNotificationCommandHandler : IRequestHandler<UpdateActivityNotificationCommand, UpdatedActivityNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityNotificationRepository _activityNotificationRepository;
        private readonly ActivityNotificationBusinessRules _activityNotificationBusinessRules;

        public UpdateActivityNotificationCommandHandler(IMapper mapper, IActivityNotificationRepository activityNotificationRepository,
                                         ActivityNotificationBusinessRules activityNotificationBusinessRules)
        {
            _mapper = mapper;
            _activityNotificationRepository = activityNotificationRepository;
            _activityNotificationBusinessRules = activityNotificationBusinessRules;
        }

        public async Task<UpdatedActivityNotificationResponse> Handle(UpdateActivityNotificationCommand request, CancellationToken cancellationToken)
        {
            ActivityNotification? activityNotification = await _activityNotificationRepository.GetAsync(predicate: an => an.Id == request.Id, cancellationToken: cancellationToken);
            await _activityNotificationBusinessRules.ActivityNotificationShouldExistWhenSelected(activityNotification);
            activityNotification = _mapper.Map(request, activityNotification);

            await _activityNotificationRepository.UpdateAsync(activityNotification!);

            UpdatedActivityNotificationResponse response = _mapper.Map<UpdatedActivityNotificationResponse>(activityNotification);
            return response;
        }
    }
}