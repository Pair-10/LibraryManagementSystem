using Application.Features.MaterialLocations.Constants;
using Application.Features.MaterialLocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialLocations.Constants.MaterialLocationsOperationClaims;

namespace Application.Features.MaterialLocations.Queries.GetById;

public class GetByIdMaterialLocationQuery : IRequest<GetByIdMaterialLocationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialLocationQueryHandler : IRequestHandler<GetByIdMaterialLocationQuery, GetByIdMaterialLocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialLocationRepository _materialLocationRepository;
        private readonly MaterialLocationBusinessRules _materialLocationBusinessRules;

        public GetByIdMaterialLocationQueryHandler(IMapper mapper, IMaterialLocationRepository materialLocationRepository, MaterialLocationBusinessRules materialLocationBusinessRules)
        {
            _mapper = mapper;
            _materialLocationRepository = materialLocationRepository;
            _materialLocationBusinessRules = materialLocationBusinessRules;
        }

        public async Task<GetByIdMaterialLocationResponse> Handle(GetByIdMaterialLocationQuery request, CancellationToken cancellationToken)
        {
            MaterialLocation? materialLocation = await _materialLocationRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _materialLocationBusinessRules.MaterialLocationShouldExistWhenSelected(materialLocation);

            GetByIdMaterialLocationResponse response = _mapper.Map<GetByIdMaterialLocationResponse>(materialLocation);
            return response;
        }
    }
}