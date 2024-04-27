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

namespace Application.Features.MaterialLocations.Commands.Update;

public class UpdateMaterialLocationCommand : IRequest<UpdatedMaterialLocationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid MaterialId { get; set; }

    public string[] Roles => [Admin, Write, MaterialLocationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialLocations"];

    public class UpdateMaterialLocationCommandHandler : IRequestHandler<UpdateMaterialLocationCommand, UpdatedMaterialLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialLocationRepository _materialLocationRepository;
        private readonly MaterialLocationBusinessRules _materialLocationBusinessRules;

        public UpdateMaterialLocationCommandHandler(IMapper mapper, IMaterialLocationRepository materialLocationRepository,
                                         MaterialLocationBusinessRules materialLocationBusinessRules)
        {
            _mapper = mapper;
            _materialLocationRepository = materialLocationRepository;
            _materialLocationBusinessRules = materialLocationBusinessRules;
        }

        public async Task<UpdatedMaterialLocationResponse> Handle(UpdateMaterialLocationCommand request, CancellationToken cancellationToken)
        {
            MaterialLocation? materialLocation = await _materialLocationRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _materialLocationBusinessRules.MaterialLocationShouldExistWhenSelected(materialLocation);
            materialLocation = _mapper.Map(request, materialLocation);

            await _materialLocationRepository.UpdateAsync(materialLocation!);

            UpdatedMaterialLocationResponse response = _mapper.Map<UpdatedMaterialLocationResponse>(materialLocation);
            return response;
        }
    }
}