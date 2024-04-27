using Application.Features.UserNotifications.Constants;
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

namespace Application.Features.UserNotifications.Commands.Delete;

public class DeleteUserNotificationCommand : IRequest<DeletedUserNotificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserNotificationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserNotifications"];

    public class DeleteUserNotificationCommandHandler : IRequestHandler<DeleteUserNotificationCommand, DeletedUserNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly UserNotificationBusinessRules _userNotificationBusinessRules;

        public DeleteUserNotificationCommandHandler(IMapper mapper, IUserNotificationRepository userNotificationRepository,
                                         UserNotificationBusinessRules userNotificationBusinessRules)
        {
            _mapper = mapper;
            _userNotificationRepository = userNotificationRepository;
            _userNotificationBusinessRules = userNotificationBusinessRules;
        }

        public async Task<DeletedUserNotificationResponse> Handle(DeleteUserNotificationCommand request, CancellationToken cancellationToken)
        {
            UserNotification? userNotification = await _userNotificationRepository.GetAsync(predicate: un => un.Id == request.Id, cancellationToken: cancellationToken);
            await _userNotificationBusinessRules.UserNotificationShouldExistWhenSelected(userNotification);

            await _userNotificationRepository.DeleteAsync(userNotification!);

            DeletedUserNotificationResponse response = _mapper.Map<DeletedUserNotificationResponse>(userNotification);
            return response;
        }
    }
}