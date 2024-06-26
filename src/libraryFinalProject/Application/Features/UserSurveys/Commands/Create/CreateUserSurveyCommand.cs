using Application.Features.UserSurveys.Constants;
using Application.Features.UserSurveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.UserSurveys.Constants.UserSurveysOperationClaims;

namespace Application.Features.UserSurveys.Commands.Create;

public class CreateUserSurveyCommand : IRequest<CreatedUserSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid SurveyId { get; set; }

    public string[] Roles => [Admin, Write, UserSurveysOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserSurveys"];

    public class CreateUserSurveyCommandHandler : IRequestHandler<CreateUserSurveyCommand, CreatedUserSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSurveyRepository _userSurveyRepository;
        private readonly UserSurveyBusinessRules _userSurveyBusinessRules;

        public CreateUserSurveyCommandHandler(IMapper mapper, IUserSurveyRepository userSurveyRepository,
                                         UserSurveyBusinessRules userSurveyBusinessRules)
        {
            _mapper = mapper;
            _userSurveyRepository = userSurveyRepository;
            _userSurveyBusinessRules = userSurveyBusinessRules;
        }

        public async Task<CreatedUserSurveyResponse> Handle(CreateUserSurveyCommand request, CancellationToken cancellationToken)
        {
            await _userSurveyBusinessRules.UserIdShouldExistWhenSelected(request.UserId, cancellationToken);
            await _userSurveyBusinessRules.SurveyIdShouldExistWhenSelected(request.SurveyId, cancellationToken);
            UserSurvey userSurvey = _mapper.Map<UserSurvey>(request);

            await _userSurveyRepository.AddAsync(userSurvey);

            CreatedUserSurveyResponse response = _mapper.Map<CreatedUserSurveyResponse>(userSurvey);
            return response;
        }
    }
}