using Application.Features.ActivityNotifications.Constants;
using Application.Features.ActivityNotifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ActivityNotifications.Constants.ActivityNotificationsOperationClaims;

namespace Application.Features.ActivityNotifications.Queries.GetById;

public class GetByIdActivityNotificationQuery : IRequest<GetByIdActivityNotificationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdActivityNotificationQueryHandler : IRequestHandler<GetByIdActivityNotificationQuery, GetByIdActivityNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IActivityNotificationRepository _activityNotificationRepository;
        private readonly ActivityNotificationBusinessRules _activityNotificationBusinessRules;

        public GetByIdActivityNotificationQueryHandler(IMapper mapper, IActivityNotificationRepository activityNotificationRepository, ActivityNotificationBusinessRules activityNotificationBusinessRules)
        {
            _mapper = mapper;
            _activityNotificationRepository = activityNotificationRepository;
            _activityNotificationBusinessRules = activityNotificationBusinessRules;
        }

        public async Task<GetByIdActivityNotificationResponse> Handle(GetByIdActivityNotificationQuery request, CancellationToken cancellationToken)
        {
            ActivityNotification? activityNotification = await _activityNotificationRepository.GetAsync(predicate: an => an.Id == request.Id, cancellationToken: cancellationToken);
            await _activityNotificationBusinessRules.ActivityNotificationShouldExistWhenSelected(activityNotification);

            GetByIdActivityNotificationResponse response = _mapper.Map<GetByIdActivityNotificationResponse>(activityNotification);
            return response;
        }
    }
}