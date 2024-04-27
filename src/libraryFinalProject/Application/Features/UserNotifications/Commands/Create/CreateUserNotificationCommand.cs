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

namespace Application.Features.UserNotifications.Commands.Create;

public class CreateUserNotificationCommand : IRequest<CreatedUserNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }

    public string[] Roles => [Admin, Write, UserNotificationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserNotifications"];

    public class CreateUserNotificationCommandHandler : IRequestHandler<CreateUserNotificationCommand, CreatedUserNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly UserNotificationBusinessRules _userNotificationBusinessRules;

        public CreateUserNotificationCommandHandler(IMapper mapper, IUserNotificationRepository userNotificationRepository,
                                         UserNotificationBusinessRules userNotificationBusinessRules)
        {
            _mapper = mapper;
            _userNotificationRepository = userNotificationRepository;
            _userNotificationBusinessRules = userNotificationBusinessRules;
        }

        public async Task<CreatedUserNotificationResponse> Handle(CreateUserNotificationCommand request, CancellationToken cancellationToken)
        {
            await _userNotificationBusinessRules.UserShouldExist(request.UserId);
            await _userNotificationBusinessRules.NotificationShouldExist(request.NotificationId);
            UserNotification userNotification = _mapper.Map<UserNotification>(request);

            await _userNotificationRepository.AddAsync(userNotification);

            CreatedUserNotificationResponse response = _mapper.Map<CreatedUserNotificationResponse>(userNotification);
            return response;
        }
    }
}