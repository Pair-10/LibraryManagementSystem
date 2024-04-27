using Application.Features.UserNotifications.Constants;
using Application.Features.UserNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserNotifications.Constants.UserNotificationsOperationClaims;

namespace Application.Features.UserNotifications.Queries.GetById;

public class GetByIdUserNotificationQuery : IRequest<GetByIdUserNotificationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUserNotificationQueryHandler : IRequestHandler<GetByIdUserNotificationQuery, GetByIdUserNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly UserNotificationBusinessRules _userNotificationBusinessRules;

        public GetByIdUserNotificationQueryHandler(IMapper mapper, IUserNotificationRepository userNotificationRepository, UserNotificationBusinessRules userNotificationBusinessRules)
        {
            _mapper = mapper;
            _userNotificationRepository = userNotificationRepository;
            _userNotificationBusinessRules = userNotificationBusinessRules;
        }

        public async Task<GetByIdUserNotificationResponse> Handle(GetByIdUserNotificationQuery request, CancellationToken cancellationToken)
        {
            UserNotification? userNotification = await _userNotificationRepository.GetAsync(predicate: un => un.Id == request.Id, cancellationToken: cancellationToken);
            await _userNotificationBusinessRules.UserNotificationShouldExistWhenSelected(userNotification);

            GetByIdUserNotificationResponse response = _mapper.Map<GetByIdUserNotificationResponse>(userNotification);
            return response;
        }
    }
}