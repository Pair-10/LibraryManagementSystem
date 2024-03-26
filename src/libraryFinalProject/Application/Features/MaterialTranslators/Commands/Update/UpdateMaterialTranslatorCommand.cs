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

namespace Application.Features.MaterialTranslators.Commands.Update;

public class UpdateMaterialTranslatorCommand : IRequest<UpdatedMaterialTranslatorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialTranslatorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTranslators"];

    public class UpdateMaterialTranslatorCommandHandler : IRequestHandler<UpdateMaterialTranslatorCommand, UpdatedMaterialTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
        private readonly MaterialTranslatorBusinessRules _materialTranslatorBusinessRules;

        public UpdateMaterialTranslatorCommandHandler(IMapper mapper, IMaterialTranslatorRepository materialTranslatorRepository,
                                         MaterialTranslatorBusinessRules materialTranslatorBusinessRules)
        {
            _mapper = mapper;
            _materialTranslatorRepository = materialTranslatorRepository;
            _materialTranslatorBusinessRules = materialTranslatorBusinessRules;
        }

        public async Task<UpdatedMaterialTranslatorResponse> Handle(UpdateMaterialTranslatorCommand request, CancellationToken cancellationToken)
        {
            MaterialTranslator? materialTranslator = await _materialTranslatorRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTranslatorBusinessRules.MaterialTranslatorShouldExistWhenSelected(materialTranslator);
            materialTranslator = _mapper.Map(request, materialTranslator);

            await _materialTranslatorRepository.UpdateAsync(materialTranslator!);

            UpdatedMaterialTranslatorResponse response = _mapper.Map<UpdatedMaterialTranslatorResponse>(materialTranslator);
            return response;
        }
    }
}