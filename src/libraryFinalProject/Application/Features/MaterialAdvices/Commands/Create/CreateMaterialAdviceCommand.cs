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
using Domain.Enums;

namespace Application.Features.MaterialAdvices.Commands.Create;

public class CreateMaterialAdviceCommand : IRequest<CreatedMaterialAdviceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public MaterialAdviceStatus.Status Status { get; set; } = MaterialAdviceStatus.Status.pending;
    public string MaterialName { get; set; }

    public string[] Roles => [Admin, Write, MaterialAdvicesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAdvices"];

    public class CreateMaterialAdviceCommandHandler : IRequestHandler<CreateMaterialAdviceCommand, CreatedMaterialAdviceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAdviceRepository _materialAdviceRepository;
        private readonly MaterialAdviceBusinessRules _materialAdviceBusinessRules;

        public CreateMaterialAdviceCommandHandler(IMapper mapper, IMaterialAdviceRepository materialAdviceRepository,
                                         MaterialAdviceBusinessRules materialAdviceBusinessRules)
        {
            _mapper = mapper;
            _materialAdviceRepository = materialAdviceRepository;
            _materialAdviceBusinessRules = materialAdviceBusinessRules;
        }

        public async Task<CreatedMaterialAdviceResponse> Handle(CreateMaterialAdviceCommand request, CancellationToken cancellationToken)
        {
            _materialAdviceBusinessRules.UserIdShouldBeExistsWhenSelected(request.UserId);
            MaterialAdvice materialAdvice = _mapper.Map<MaterialAdvice>(request);

            await _materialAdviceRepository.AddAsync(materialAdvice);

            CreatedMaterialAdviceResponse response = _mapper.Map<CreatedMaterialAdviceResponse>(materialAdvice);
            return response;
        }
    }
}