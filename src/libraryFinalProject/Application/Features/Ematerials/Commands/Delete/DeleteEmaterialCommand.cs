using Application.Features.Ematerials.Constants;
using Application.Features.Ematerials.Constants;
using Application.Features.Ematerials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ematerials.Constants.EmaterialsOperationClaims;

namespace Application.Features.Ematerials.Commands.Delete;

public class DeleteEmaterialCommand : IRequest<DeletedEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, EmaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterials"];

    public class DeleteEmaterialCommandHandler : IRequestHandler<DeleteEmaterialCommand, DeletedEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialRepository _ematerialRepository;
        private readonly EmaterialBusinessRules _ematerialBusinessRules;

        public DeleteEmaterialCommandHandler(IMapper mapper, IEmaterialRepository ematerialRepository,
                                         EmaterialBusinessRules ematerialBusinessRules)
        {
            _mapper = mapper;
            _ematerialRepository = ematerialRepository;
            _ematerialBusinessRules = ematerialBusinessRules;
        }

        public async Task<DeletedEmaterialResponse> Handle(DeleteEmaterialCommand request, CancellationToken cancellationToken)
        {
            Ematerial? ematerial = await _ematerialRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialBusinessRules.EmaterialShouldExistWhenSelected(ematerial);

            await _ematerialRepository.DeleteAsync(ematerial!);

            DeletedEmaterialResponse response = _mapper.Map<DeletedEmaterialResponse>(ematerial);
            return response;
        }
    }
}