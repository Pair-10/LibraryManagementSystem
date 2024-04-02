using Application.Features.UserNotifications.Constants;
using Application.Features.UserNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserNotifications.Constants.UserNotificationsOperationClaims;

namespace Application.Features.UserNotifications.Commands.Update;

public class UpdateUserNotificationCommand : IRequest<UpdatedUserNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, UserNotificationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserNotifications"];

    public class UpdateUserNotificationCommandHandler : IRequestHandler<UpdateUserNotificationCommand, UpdatedUserNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly UserNotificationBusinessRules _userNotificationBusinessRules;

        public UpdateUserNotificationCommandHandler(IMapper mapper, IUserNotificationRepository userNotificationRepository,
                                         UserNotificationBusinessRules userNotificationBusinessRules)
        {
            _mapper = mapper;
            _userNotificationRepository = userNotificationRepository;
            _userNotificationBusinessRules = userNotificationBusinessRules;
        }

        public async Task<UpdatedUserNotificationResponse> Handle(UpdateUserNotificationCommand request, CancellationToken cancellationToken)
        {
            await _userNotificationBusinessRules.UserShouldExist(request.UserId);
            await _userNotificationBusinessRules.NotificationShouldExist(request.NotificationId);
            UserNotification? userNotification = await _userNotificationRepository.GetAsync(predicate: un => un.Id == request.Id, cancellationToken: cancellationToken);
            await _userNotificationBusinessRules.UserNotificationShouldExistWhenSelected(userNotification);
            userNotification = _mapper.Map(request, userNotification);

            await _userNotificationRepository.UpdateAsync(userNotification!);

            UpdatedUserNotificationResponse response = _mapper.Map<UpdatedUserNotificationResponse>(userNotification);
            return response;
        }
    }
}