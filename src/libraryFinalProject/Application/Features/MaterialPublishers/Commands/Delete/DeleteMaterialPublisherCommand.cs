using Application.Features.MaterialPublishers.Constants;
using Application.Features.MaterialPublishers.Constants;
using Application.Features.MaterialPublishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialPublishers.Constants.MaterialPublishersOperationClaims;

namespace Application.Features.MaterialPublishers.Commands.Delete;

public class DeleteMaterialPublisherCommand : IRequest<DeletedMaterialPublisherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialPublishersOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPublishers"];

    public class DeleteMaterialPublisherCommandHandler : IRequestHandler<DeleteMaterialPublisherCommand, DeletedMaterialPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPublisherRepository _materialPublisherRepository;
        private readonly MaterialPublisherBusinessRules _materialPublisherBusinessRules;

        public DeleteMaterialPublisherCommandHandler(IMapper mapper, IMaterialPublisherRepository materialPublisherRepository,
                                         MaterialPublisherBusinessRules materialPublisherBusinessRules)
        {
            _mapper = mapper;
            _materialPublisherRepository = materialPublisherRepository;
            _materialPublisherBusinessRules = materialPublisherBusinessRules;
        }

        public async Task<DeletedMaterialPublisherResponse> Handle(DeleteMaterialPublisherCommand request, CancellationToken cancellationToken)
        {
            MaterialPublisher? materialPublisher = await _materialPublisherRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPublisherBusinessRules.MaterialPublisherShouldExistWhenSelected(materialPublisher);

            await _materialPublisherRepository.DeleteAsync(materialPublisher!);

            DeletedMaterialPublisherResponse response = _mapper.Map<DeletedMaterialPublisherResponse>(materialPublisher);
            return response;
        }
    }
}