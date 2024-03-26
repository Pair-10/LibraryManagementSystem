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

namespace Application.Features.MaterialTranslators.Commands.Create;

public class CreateMaterialTranslatorCommand : IRequest<CreatedMaterialTranslatorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialTranslatorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialTranslators"];

    public class CreateMaterialTranslatorCommandHandler : IRequestHandler<CreateMaterialTranslatorCommand, CreatedMaterialTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
        private readonly MaterialTranslatorBusinessRules _materialTranslatorBusinessRules;

        public CreateMaterialTranslatorCommandHandler(IMapper mapper, IMaterialTranslatorRepository materialTranslatorRepository,
                                         MaterialTranslatorBusinessRules materialTranslatorBusinessRules)
        {
            _mapper = mapper;
            _materialTranslatorRepository = materialTranslatorRepository;
            _materialTranslatorBusinessRules = materialTranslatorBusinessRules;
        }

        public async Task<CreatedMaterialTranslatorResponse> Handle(CreateMaterialTranslatorCommand request, CancellationToken cancellationToken)
        {
            MaterialTranslator materialTranslator = _mapper.Map<MaterialTranslator>(request);

            await _materialTranslatorRepository.AddAsync(materialTranslator);

            CreatedMaterialTranslatorResponse response = _mapper.Map<CreatedMaterialTranslatorResponse>(materialTranslator);
            return response;
        }
    }
}