using Application.Features.MaterialLocations.Constants;
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

namespace Application.Features.MaterialLocations.Commands.Delete;

public class DeleteMaterialLocationCommand : IRequest<DeletedMaterialLocationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialLocationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialLocations"];

    public class DeleteMaterialLocationCommandHandler : IRequestHandler<DeleteMaterialLocationCommand, DeletedMaterialLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialLocationRepository _materialLocationRepository;
        private readonly MaterialLocationBusinessRules _materialLocationBusinessRules;

        public DeleteMaterialLocationCommandHandler(IMapper mapper, IMaterialLocationRepository materialLocationRepository,
                                         MaterialLocationBusinessRules materialLocationBusinessRules)
        {
            _mapper = mapper;
            _materialLocationRepository = materialLocationRepository;
            _materialLocationBusinessRules = materialLocationBusinessRules;
        }

        public async Task<DeletedMaterialLocationResponse> Handle(DeleteMaterialLocationCommand request, CancellationToken cancellationToken)
        {
            MaterialLocation? materialLocation = await _materialLocationRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _materialLocationBusinessRules.MaterialLocationShouldExistWhenSelected(materialLocation);

            await _materialLocationRepository.DeleteAsync(materialLocation!);

            DeletedMaterialLocationResponse response = _mapper.Map<DeletedMaterialLocationResponse>(materialLocation);
            return response;
        }
    }
}