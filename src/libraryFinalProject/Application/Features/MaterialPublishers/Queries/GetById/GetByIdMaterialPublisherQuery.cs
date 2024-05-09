using Application.Features.MaterialPublishers.Constants;
using Application.Features.MaterialPublishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialPublishers.Constants.MaterialPublishersOperationClaims;

namespace Application.Features.MaterialPublishers.Queries.GetById;

public class GetByIdMaterialPublisherQuery : IRequest<GetByIdMaterialPublisherResponse>
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialPublisherQueryHandler : IRequestHandler<GetByIdMaterialPublisherQuery, GetByIdMaterialPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialPublisherRepository _materialPublisherRepository;
        private readonly MaterialPublisherBusinessRules _materialPublisherBusinessRules;

        public GetByIdMaterialPublisherQueryHandler(IMapper mapper, IMaterialPublisherRepository materialPublisherRepository, MaterialPublisherBusinessRules materialPublisherBusinessRules)
        {
            _mapper = mapper;
            _materialPublisherRepository = materialPublisherRepository;
            _materialPublisherBusinessRules = materialPublisherBusinessRules;
        }

        public async Task<GetByIdMaterialPublisherResponse> Handle(GetByIdMaterialPublisherQuery request, CancellationToken cancellationToken)
        {
            MaterialPublisher? materialPublisher = await _materialPublisherRepository.GetAsync(predicate: mp => mp.Id == request.Id, cancellationToken: cancellationToken);
            await _materialPublisherBusinessRules.MaterialPublisherShouldExistWhenSelected(materialPublisher);

            GetByIdMaterialPublisherResponse response = _mapper.Map<GetByIdMaterialPublisherResponse>(materialPublisher);
            return response;
        }
    }
}