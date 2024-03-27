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

namespace Application.Features.MaterialAdvices.Commands.Update;

public class UpdateMaterialAdviceCommand : IRequest<UpdatedMaterialAdviceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public string Status { get; set; }
    public string MaterialName { get; set; }

    public string[] Roles => [Admin, Write, MaterialAdvicesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAdvices"];

    public class UpdateMaterialAdviceCommandHandler : IRequestHandler<UpdateMaterialAdviceCommand, UpdatedMaterialAdviceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAdviceRepository _materialAdviceRepository;
        private readonly MaterialAdviceBusinessRules _materialAdviceBusinessRules;

        public UpdateMaterialAdviceCommandHandler(IMapper mapper, IMaterialAdviceRepository materialAdviceRepository,
                                         MaterialAdviceBusinessRules materialAdviceBusinessRules)
        {
            _mapper = mapper;
            _materialAdviceRepository = materialAdviceRepository;
            _materialAdviceBusinessRules = materialAdviceBusinessRules;
        }

        public async Task<UpdatedMaterialAdviceResponse> Handle(UpdateMaterialAdviceCommand request, CancellationToken cancellationToken)
        {
            MaterialAdvice? materialAdvice = await _materialAdviceRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAdviceBusinessRules.MaterialAdviceShouldExistWhenSelected(materialAdvice);
            materialAdvice = _mapper.Map(request, materialAdvice);

            await _materialAdviceRepository.UpdateAsync(materialAdvice!);

            UpdatedMaterialAdviceResponse response = _mapper.Map<UpdatedMaterialAdviceResponse>(materialAdvice);
            return response;
        }
    }
}