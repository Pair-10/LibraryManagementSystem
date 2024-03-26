using Application.Features.Returneds.Constants;
using Application.Features.Returneds.Constants;
using Application.Features.Returneds.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Returneds.Constants.ReturnedsOperationClaims;

namespace Application.Features.Returneds.Commands.Delete;

public class DeleteReturnedCommand : IRequest<DeletedReturnedResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ReturnedsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturneds"];

    public class DeleteReturnedCommandHandler : IRequestHandler<DeleteReturnedCommand, DeletedReturnedResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnedRepository _returnedRepository;
        private readonly ReturnedBusinessRules _returnedBusinessRules;

        public DeleteReturnedCommandHandler(IMapper mapper, IReturnedRepository returnedRepository,
                                         ReturnedBusinessRules returnedBusinessRules)
        {
            _mapper = mapper;
            _returnedRepository = returnedRepository;
            _returnedBusinessRules = returnedBusinessRules;
        }

        public async Task<DeletedReturnedResponse> Handle(DeleteReturnedCommand request, CancellationToken cancellationToken)
        {
            Returned? returned = await _returnedRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnedBusinessRules.ReturnedShouldExistWhenSelected(returned);

            await _returnedRepository.DeleteAsync(returned!);

            DeletedReturnedResponse response = _mapper.Map<DeletedReturnedResponse>(returned);
            return response;
        }
    }
}