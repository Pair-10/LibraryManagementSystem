using Application.Features.OrderEMaterials.Constants;
using Application.Features.OrderEMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.OrderEMaterials.Constants.OrderEMaterialsOperationClaims;

namespace Application.Features.OrderEMaterials.Queries.GetById;

public class GetByIdOrderEMaterialQuery : IRequest<GetByIdOrderEMaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdOrderEMaterialQueryHandler : IRequestHandler<GetByIdOrderEMaterialQuery, GetByIdOrderEMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEMaterialRepository _orderEMaterialRepository;
        private readonly OrderEMaterialBusinessRules _orderEMaterialBusinessRules;

        public GetByIdOrderEMaterialQueryHandler(IMapper mapper, IOrderEMaterialRepository orderEMaterialRepository, OrderEMaterialBusinessRules orderEMaterialBusinessRules)
        {
            _mapper = mapper;
            _orderEMaterialRepository = orderEMaterialRepository;
            _orderEMaterialBusinessRules = orderEMaterialBusinessRules;
        }

        public async Task<GetByIdOrderEMaterialResponse> Handle(GetByIdOrderEMaterialQuery request, CancellationToken cancellationToken)
        {
            OrderEMaterial? orderEMaterial = await _orderEMaterialRepository.GetAsync(predicate: oem => oem.Id == request.Id, cancellationToken: cancellationToken);
            await _orderEMaterialBusinessRules.OrderEMaterialShouldExistWhenSelected(orderEMaterial);

            GetByIdOrderEMaterialResponse response = _mapper.Map<GetByIdOrderEMaterialResponse>(orderEMaterial);
            return response;
        }
    }
}