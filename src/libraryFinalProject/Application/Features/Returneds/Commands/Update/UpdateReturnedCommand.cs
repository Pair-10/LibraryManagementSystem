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

namespace Application.Features.Returneds.Commands.Update;

public class UpdateReturnedCommand : IRequest<UpdatedReturnedResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public Guid BorrowedMaterialId { get; set; }
    public Guid PenaltyId { get; set; }
    public bool IsPenalised { get; set; }

    public string[] Roles => [Admin, Write, ReturnedsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturneds"];

    public class UpdateReturnedCommandHandler : IRequestHandler<UpdateReturnedCommand, UpdatedReturnedResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnedRepository _returnedRepository;
        private readonly ReturnedBusinessRules _returnedBusinessRules;

        public UpdateReturnedCommandHandler(IMapper mapper, IReturnedRepository returnedRepository,
                                         ReturnedBusinessRules returnedBusinessRules)
        {
            _mapper = mapper;
            _returnedRepository = returnedRepository;
            _returnedBusinessRules = returnedBusinessRules;
        }

        public async Task<UpdatedReturnedResponse> Handle(UpdateReturnedCommand request, CancellationToken cancellationToken)
        {
            await _returnedBusinessRules.BorrowedMaterialIdShouldExistWhenSelected(request.BorrowedMaterialId, cancellationToken);
            await _returnedBusinessRules.CheckingTheDeliveryTime(request.UserId, cancellationToken);
            Returned? returned = await _returnedRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnedBusinessRules.ReturnedShouldExistWhenSelected(returned);
            returned = _mapper.Map(request, returned);

            await _returnedRepository.UpdateAsync(returned!);

            UpdatedReturnedResponse response = _mapper.Map<UpdatedReturnedResponse>(returned);
            return response;
        }
    }
}