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

namespace Application.Features.Returns.Commands.Create;

public class CreateReturnCommand : IRequest<CreatedReturnResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }

    public string[] Roles => [Admin, Write, ReturnsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturns"];

    public class CreateReturnCommandHandler : IRequestHandler<CreateReturnCommand, CreatedReturnResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnRepository _returnRepository;
        private readonly ReturnBusinessRules _returnBusinessRules;

        public CreateReturnCommandHandler(IMapper mapper, IReturnRepository returnRepository,
                                         ReturnBusinessRules returnBusinessRules)
        {
            _mapper = mapper;
            _returnRepository = returnRepository;
            _returnBusinessRules = returnBusinessRules;
        }

        public async Task<CreatedReturnResponse> Handle(CreateReturnCommand request, CancellationToken cancellationToken)
        {
            Return return = _mapper.Map<Return>(request);

            await _returnRepository.AddAsync(return);

            CreatedReturnResponse response = _mapper.Map<CreatedReturnResponse>(return);
            return response;
        }
    }
}