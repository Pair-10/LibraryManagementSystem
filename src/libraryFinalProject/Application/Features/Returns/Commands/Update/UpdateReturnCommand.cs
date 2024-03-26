using Application.Features.Returns.Constants;
using Application.Features.Returns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Returns.Constants.ReturnsOperationClaims;

namespace Application.Features.Returns.Commands.Update;

public class UpdateReturnCommand : IRequest<UpdatedReturnResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }

    public string[] Roles => [Admin, Write, ReturnsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturns"];

    public class UpdateReturnCommandHandler : IRequestHandler<UpdateReturnCommand, UpdatedReturnResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnRepository _returnRepository;
        private readonly ReturnBusinessRules _returnBusinessRules;

        public UpdateReturnCommandHandler(IMapper mapper, IReturnRepository returnRepository,
                                         ReturnBusinessRules returnBusinessRules)
        {
            _mapper = mapper;
            _returnRepository = returnRepository;
            _returnBusinessRules = returnBusinessRules;
        }

        public async Task<UpdatedReturnResponse> Handle(UpdateReturnCommand request, CancellationToken cancellationToken)
        {
            Return? return = await _returnRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnBusinessRules.ReturnShouldExistWhenSelected(return);
            return = _mapper.Map(request, return);

            await _returnRepository.UpdateAsync(return!);

            UpdatedReturnResponse response = _mapper.Map<UpdatedReturnResponse>(return);
            return response;
        }
    }
}