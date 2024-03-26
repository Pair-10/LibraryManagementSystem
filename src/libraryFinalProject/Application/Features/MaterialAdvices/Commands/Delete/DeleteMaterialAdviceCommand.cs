using Application.Features.MaterialAdvices.Constants;
using Application.Features.MaterialAdvices.Constants;
using Application.Features.MaterialAdvices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialAdvices.Constants.MaterialAdvicesOperationClaims;

namespace Application.Features.MaterialAdvices.Commands.Delete;

public class DeleteMaterialAdviceCommand : IRequest<DeletedMaterialAdviceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialAdvicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAdvices"];

    public class DeleteMaterialAdviceCommandHandler : IRequestHandler<DeleteMaterialAdviceCommand, DeletedMaterialAdviceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAdviceRepository _materialAdviceRepository;
        private readonly MaterialAdviceBusinessRules _materialAdviceBusinessRules;

        public DeleteMaterialAdviceCommandHandler(IMapper mapper, IMaterialAdviceRepository materialAdviceRepository,
                                         MaterialAdviceBusinessRules materialAdviceBusinessRules)
        {
            _mapper = mapper;
            _materialAdviceRepository = materialAdviceRepository;
            _materialAdviceBusinessRules = materialAdviceBusinessRules;
        }

        public async Task<DeletedMaterialAdviceResponse> Handle(DeleteMaterialAdviceCommand request, CancellationToken cancellationToken)
        {
            MaterialAdvice? materialAdvice = await _materialAdviceRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAdviceBusinessRules.MaterialAdviceShouldExistWhenSelected(materialAdvice);

            await _materialAdviceRepository.DeleteAsync(materialAdvice!);

            DeletedMaterialAdviceResponse response = _mapper.Map<DeletedMaterialAdviceResponse>(materialAdvice);
            return response;
        }
    }
}