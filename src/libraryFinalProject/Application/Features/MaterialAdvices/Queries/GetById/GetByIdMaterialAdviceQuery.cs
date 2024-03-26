using Application.Features.MaterialAdvices.Constants;
using Application.Features.MaterialAdvices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialAdvices.Constants.MaterialAdvicesOperationClaims;

namespace Application.Features.MaterialAdvices.Queries.GetById;

public class GetByIdMaterialAdviceQuery : IRequest<GetByIdMaterialAdviceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialAdviceQueryHandler : IRequestHandler<GetByIdMaterialAdviceQuery, GetByIdMaterialAdviceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAdviceRepository _materialAdviceRepository;
        private readonly MaterialAdviceBusinessRules _materialAdviceBusinessRules;

        public GetByIdMaterialAdviceQueryHandler(IMapper mapper, IMaterialAdviceRepository materialAdviceRepository, MaterialAdviceBusinessRules materialAdviceBusinessRules)
        {
            _mapper = mapper;
            _materialAdviceRepository = materialAdviceRepository;
            _materialAdviceBusinessRules = materialAdviceBusinessRules;
        }

        public async Task<GetByIdMaterialAdviceResponse> Handle(GetByIdMaterialAdviceQuery request, CancellationToken cancellationToken)
        {
            MaterialAdvice? materialAdvice = await _materialAdviceRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAdviceBusinessRules.MaterialAdviceShouldExistWhenSelected(materialAdvice);

            GetByIdMaterialAdviceResponse response = _mapper.Map<GetByIdMaterialAdviceResponse>(materialAdvice);
            return response;
        }
    }
}