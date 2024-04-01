using Application.Features.OrderEMaterials.Constants;
using Application.Features.OrderEMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrderEMaterials.Constants.OrderEMaterialsOperationClaims;

namespace Application.Features.OrderEMaterials.Commands.Update;

public class UpdateOrderEMaterialCommand : IRequest<UpdatedOrderEMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid EMaterialId { get; set; }
    public Guid OrderId { get; set; }
    public decimal QuantityPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public string[] Roles => [Admin, Write, OrderEMaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderEMaterials"];

    public class UpdateOrderEMaterialCommandHandler : IRequestHandler<UpdateOrderEMaterialCommand, UpdatedOrderEMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEMaterialRepository _orderEMaterialRepository;
        private readonly OrderEMaterialBusinessRules _orderEMaterialBusinessRules;

        public UpdateOrderEMaterialCommandHandler(IMapper mapper, IOrderEMaterialRepository orderEMaterialRepository,
                                         OrderEMaterialBusinessRules orderEMaterialBusinessRules)
        {
            _mapper = mapper;
            _orderEMaterialRepository = orderEMaterialRepository;
            _orderEMaterialBusinessRules = orderEMaterialBusinessRules;
        }

        public async Task<UpdatedOrderEMaterialResponse> Handle(UpdateOrderEMaterialCommand request, CancellationToken cancellationToken)
        {
            await _orderEMaterialBusinessRules.EMaterialRelationshipsShouldBeValid(request.EMaterialId);
            await _orderEMaterialBusinessRules.OrderRelationshipsShouldBeValid(request.OrderId);
            OrderEMaterial? orderEMaterial = await _orderEMaterialRepository.GetAsync(predicate: oem => oem.Id == request.Id, cancellationToken: cancellationToken);
            await _orderEMaterialBusinessRules.OrderEMaterialShouldExistWhenSelected(orderEMaterial);
            orderEMaterial = _mapper.Map(request, orderEMaterial);

            await _orderEMaterialRepository.UpdateAsync(orderEMaterial!);

            UpdatedOrderEMaterialResponse response = _mapper.Map<UpdatedOrderEMaterialResponse>(orderEMaterial);
            return response;
        }
    }
}