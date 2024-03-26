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

namespace Application.Features.MaterialPublishers.Commands.Update;

public class UpdateMaterialPublisherCommand : IRequest<UpdatedMaterialPublisherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }

    public string[] Roles => [Admin, Write, MaterialPublishersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPublishers"];

    public class UpdateMaterialPublisherCommandHandler : IRequestHandler<UpdateMaterialPublisherCommand, UpdatedMaterialPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPublisherRepository _materialPublisherRepository;
        private readonly MaterialPublisherBusinessRules _materialPublisherBusinessRules;

        public UpdateMaterialPublisherCommandHandler(IMapper mapper, IMaterialPublisherRepository materialPublisherRepository,
                                         MaterialPublisherBusinessRules materialPublisherBusinessRules)
        {
            _mapper = mapper;
            _materialPublisherRepository = materialPublisherRepository;
            _materialPublisherBusinessRules = materialPublisherBusinessRules;
        }

        public async Task<UpdatedMaterialPublisherResponse> Handle(UpdateMaterialPublisherCommand request, CancellationToken cancellationToken)
        {
            MaterialPublisher? materialPublisher = await _materialPublisherRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPublisherBusinessRules.MaterialPublisherShouldExistWhenSelected(materialPublisher);
            materialPublisher = _mapper.Map(request, materialPublisher);

            await _materialPublisherRepository.UpdateAsync(materialPublisher!);

            UpdatedMaterialPublisherResponse response = _mapper.Map<UpdatedMaterialPublisherResponse>(materialPublisher);
            return response;
        }
    }
}