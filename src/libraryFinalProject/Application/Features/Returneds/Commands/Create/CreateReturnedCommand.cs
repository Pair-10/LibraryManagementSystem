using Application.Features.Returneds.Constants;
using Application.Features.Returneds.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Returneds.Constants.ReturnedsOperationClaims;

namespace Application.Features.Returneds.Commands.Create;

public class CreateReturnedCommand : IRequest<CreatedReturnedResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }

    public string[] Roles => [Admin, Write, ReturnedsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturneds"];

    public class CreateReturnedCommandHandler : IRequestHandler<CreateReturnedCommand, CreatedReturnedResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnedRepository _returnedRepository;
        private readonly ReturnedBusinessRules _returnedBusinessRules;
        public CreateReturnedCommandHandler(IMapper mapper, IReturnedRepository returnedRepository,
                                         ReturnedBusinessRules returnedBusinessRules)
        {
            _mapper = mapper;
            _returnedRepository = returnedRepository;
            _returnedBusinessRules = returnedBusinessRules;
        }

        public async Task<CreatedReturnedResponse> Handle(CreateReturnedCommand request, CancellationToken cancellationToken)
        {
            await _returnedBusinessRules.BorrowedMaterialIdShouldExistWhenSelected(request.BorrowedMaterialId, cancellationToken);
            await _returnedBusinessRules.CheckingTheDeliveryTime(request.UserId, cancellationToken);


            Returned returned = _mapper.Map<Returned>(request);

            await _returnedRepository.AddAsync(returned);

            CreatedReturnedResponse response = _mapper.Map<CreatedReturnedResponse>(returned);
            return response;
        }
    }
}