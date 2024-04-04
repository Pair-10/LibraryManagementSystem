using Application.Features.MaterialLocations.Constants;
using Application.Features.MaterialLocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialLocations.Constants.MaterialLocationsOperationClaims;

namespace Application.Features.MaterialLocations.Commands.Create;

public class CreateMaterialLocationCommand : IRequest<CreatedMaterialLocationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialLocationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialLocations"];

    public class CreateMaterialLocationCommandHandler : IRequestHandler<CreateMaterialLocationCommand, CreatedMaterialLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialLocationRepository _materialLocationRepository;
        private readonly MaterialLocationBusinessRules _materialLocationBusinessRules;

        public CreateMaterialLocationCommandHandler(IMapper mapper, IMaterialLocationRepository materialLocationRepository,
                                         MaterialLocationBusinessRules materialLocationBusinessRules)
        {
            _mapper = mapper;
            _materialLocationRepository = materialLocationRepository;
            _materialLocationBusinessRules = materialLocationBusinessRules;
        }

        public async Task<CreatedMaterialLocationResponse> Handle(CreateMaterialLocationCommand request, CancellationToken cancellationToken)
        {
            await _materialLocationBusinessRules.MaterialIdShouldExistWhenSelected(request.MaterialId,cancellationToken);
            await _materialLocationBusinessRules.LocationIdShouldExistWhenSelected(request.LocationId, cancellationToken);
            MaterialLocation materialLocation = _mapper.Map<MaterialLocation>(request);

            await _materialLocationRepository.AddAsync(materialLocation);

            CreatedMaterialLocationResponse response = _mapper.Map<CreatedMaterialLocationResponse>(materialLocation);
            return response;
        }
    }
}