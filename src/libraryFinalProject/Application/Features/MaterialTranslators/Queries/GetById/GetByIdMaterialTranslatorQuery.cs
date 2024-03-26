using Application.Features.MaterialTranslators.Constants;
using Application.Features.MaterialTranslators.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialTranslators.Constants.MaterialTranslatorsOperationClaims;

namespace Application.Features.MaterialTranslators.Queries.GetById;

public class GetByIdMaterialTranslatorQuery : IRequest<GetByIdMaterialTranslatorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialTranslatorQueryHandler : IRequestHandler<GetByIdMaterialTranslatorQuery, GetByIdMaterialTranslatorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTranslatorRepository _materialTranslatorRepository;
        private readonly MaterialTranslatorBusinessRules _materialTranslatorBusinessRules;

        public GetByIdMaterialTranslatorQueryHandler(IMapper mapper, IMaterialTranslatorRepository materialTranslatorRepository, MaterialTranslatorBusinessRules materialTranslatorBusinessRules)
        {
            _mapper = mapper;
            _materialTranslatorRepository = materialTranslatorRepository;
            _materialTranslatorBusinessRules = materialTranslatorBusinessRules;
        }

        public async Task<GetByIdMaterialTranslatorResponse> Handle(GetByIdMaterialTranslatorQuery request, CancellationToken cancellationToken)
        {
            MaterialTranslator? materialTranslator = await _materialTranslatorRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _materialTranslatorBusinessRules.MaterialTranslatorShouldExistWhenSelected(materialTranslator);

            GetByIdMaterialTranslatorResponse response = _mapper.Map<GetByIdMaterialTranslatorResponse>(materialTranslator);
            return response;
        }
    }
}