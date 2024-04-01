using Application.Features.Penalties.Constants;
using Application.Features.Penalties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System.Runtime.InteropServices;
using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommand : IRequest<CreatedPenaltyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ReturnedId { get; set; }
    public Guid PaymentId { get; set; }
    public decimal PenaltyPrice { get; set; }
    public DateTime PenaltyDate { get; set; }
    public bool PenaltyStatus { get; set; }

    public string[] Roles => [Admin, Write, PenaltiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenalties"];

    public class CreatePenaltyCommandHandler : IRequestHandler<CreatePenaltyCommand, CreatedPenaltyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyBusinessRules _penaltyBusinessRules;

        public CreatePenaltyCommandHandler(IMapper mapper, IPenaltyRepository penaltyRepository,
                                         PenaltyBusinessRules penaltyBusinessRules)
        {
            _mapper = mapper;
            _penaltyRepository = penaltyRepository;
            _penaltyBusinessRules = penaltyBusinessRules;
        }

        public async Task<CreatedPenaltyResponse> Handle(CreatePenaltyCommand request, CancellationToken cancellationToken)
        {
            await _penaltyBusinessRules.ReturnedIdShouldExist(request.ReturnedId);
            await _penaltyBusinessRules.PaymentIdShouldExist(request.PaymentId);
            Penalty penalty = _mapper.Map<Penalty>(request);

            await _penaltyRepository.AddAsync(penalty);

            CreatedPenaltyResponse response = _mapper.Map<CreatedPenaltyResponse>(penalty);
            return response;
        }
    }
}