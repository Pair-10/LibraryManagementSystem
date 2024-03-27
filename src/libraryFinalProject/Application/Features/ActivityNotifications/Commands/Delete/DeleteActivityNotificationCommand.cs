using Application.Features.ActivityNotifications.Constants;
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

namespace Application.Features.ActivityNotifications.Commands.Delete;

public class DeleteActivityNotificationCommand : IRequest<DeletedActivityNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ActivityNotificationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetActivityNotifications"];

    public class DeleteActivityNotificationCommandHandler : IRequestHandler<DeleteActivityNotificationCommand, DeletedActivityNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityNotificationRepository _activityNotificationRepository;
        private readonly ActivityNotificationBusinessRules _activityNotificationBusinessRules;

        public DeleteActivityNotificationCommandHandler(IMapper mapper, IActivityNotificationRepository activityNotificationRepository,
                                         ActivityNotificationBusinessRules activityNotificationBusinessRules)
        {
            _mapper = mapper;
            _activityNotificationRepository = activityNotificationRepository;
            _activityNotificationBusinessRules = activityNotificationBusinessRules;
        }

        public async Task<DeletedActivityNotificationResponse> Handle(DeleteActivityNotificationCommand request, CancellationToken cancellationToken)
        {
            ActivityNotification? activityNotification = await _activityNotificationRepository.GetAsync(predicate: an => an.Id == request.Id, cancellationToken: cancellationToken);
            await _activityNotificationBusinessRules.ActivityNotificationShouldExistWhenSelected(activityNotification);

            await _activityNotificationRepository.DeleteAsync(activityNotification!);

            DeletedActivityNotificationResponse response = _mapper.Map<DeletedActivityNotificationResponse>(activityNotification);
            return response;
        }
    }
}