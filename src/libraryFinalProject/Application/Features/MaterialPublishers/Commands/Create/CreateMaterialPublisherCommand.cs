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

namespace Application.Features.MaterialPublishers.Commands.Create;

public class CreateMaterialPublisherCommand : IRequest<CreatedMaterialPublisherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid MaterialId { get; set; }
    public Guid PuslisherId { get; set; }

    public string[] Roles => [Admin, Write, MaterialPublishersOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialPublishers"];

    public class CreateMaterialPublisherCommandHandler : IRequestHandler<CreateMaterialPublisherCommand, CreatedMaterialPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPublisherRepository _materialPublisherRepository;
        private readonly MaterialPublisherBusinessRules _materialPublisherBusinessRules;

        public CreateMaterialPublisherCommandHandler(IMapper mapper, IMaterialPublisherRepository materialPublisherRepository,
                                         MaterialPublisherBusinessRules materialPublisherBusinessRules)
        {
            _mapper = mapper;
            _materialPublisherRepository = materialPublisherRepository;
            _materialPublisherBusinessRules = materialPublisherBusinessRules;
        }

        public async Task<CreatedMaterialPublisherResponse> Handle(CreateMaterialPublisherCommand request, CancellationToken cancellationToken)
        {
            _materialPublisherBusinessRules.MaterialIdShouldExistWhenSelected(request.MaterialId, cancellationToken);
            _materialPublisherBusinessRules.PublisherIdShouldExistWhenSelected(request.PuslisherId, cancellationToken);
            MaterialPublisher materialPublisher = _mapper.Map<MaterialPublisher>(request);

            await _materialPublisherRepository.AddAsync(materialPublisher);

            CreatedMaterialPublisherResponse response = _mapper.Map<CreatedMaterialPublisherResponse>(materialPublisher);
            return response;
        }
    }
}