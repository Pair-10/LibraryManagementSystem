using Application.Features.MaterialTranslators.Constants;
using Application.Features.MaterialTranslators.Constants;
using Application.Features.MaterialTranslators.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialTranslators.Constants.MaterialTranslatorsOperationClaims;

namespace Application.Features.MaterialTranslators.Commands.Delete;

public class DeleteMaterialTranslatorCommand : IRequest<DeletedMaterialTranslatorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialTranslatorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTranslators"];

    public class DeleteMaterialTranslatorCommandHandler : IRequestHandler<DeleteMaterialTranslatorCommand, DeletedMaterialTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
        private readonly MaterialTranslatorBusinessRules _materialTranslatorBusinessRules;

        public DeleteMaterialTranslatorCommandHandler(IMapper mapper, IMaterialTranslatorRepository materialTranslatorRepository,
                                         MaterialTranslatorBusinessRules materialTranslatorBusinessRules)
        {
            _mapper = mapper;
            _materialTranslatorRepository = materialTranslatorRepository;
            _materialTranslatorBusinessRules = materialTranslatorBusinessRules;
        }

        public async Task<DeletedMaterialTranslatorResponse> Handle(DeleteMaterialTranslatorCommand request, CancellationToken cancellationToken)
        {
            MaterialTranslator? materialTranslator = await _materialTranslatorRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTranslatorBusinessRules.MaterialTranslatorShouldExistWhenSelected(materialTranslator);

            await _materialTranslatorRepository.DeleteAsync(materialTranslator!);

            DeletedMaterialTranslatorResponse response = _mapper.Map<DeletedMaterialTranslatorResponse>(materialTranslator);
            return response;
        }
    }
}