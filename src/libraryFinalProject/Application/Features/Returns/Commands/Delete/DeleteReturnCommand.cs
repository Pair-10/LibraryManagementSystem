using Application.Features.Returns.Constants;
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

namespace Application.Features.Returns.Commands.Delete;

public class DeleteReturnCommand : IRequest<DeletedReturnResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ReturnsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReturns"];

    public class DeleteReturnCommandHandler : IRequestHandler<DeleteReturnCommand, DeletedReturnResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnRepository _returnRepository;
        private readonly ReturnBusinessRules _returnBusinessRules;

        public DeleteReturnCommandHandler(IMapper mapper, IReturnRepository returnRepository,
                                         ReturnBusinessRules returnBusinessRules)
        {
            _mapper = mapper;
            _returnRepository = returnRepository;
            _returnBusinessRules = returnBusinessRules;
        }

        public async Task<DeletedReturnResponse> Handle(DeleteReturnCommand request, CancellationToken cancellationToken)
        {
            Return? return = await _returnRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnBusinessRules.ReturnShouldExistWhenSelected(return);

            await _returnRepository.DeleteAsync(return!);

            DeletedReturnResponse response = _mapper.Map<DeletedReturnResponse>(return);
            return response;
        }
    }
}