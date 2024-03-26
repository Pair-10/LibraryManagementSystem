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

namespace Application.Features.OrderEMaterials.Commands.Create;

public class CreateOrderEMaterialCommand : IRequest<CreatedOrderEMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid EMaterialId { get; set; }
    public Guid OrderId { get; set; }
    public decimal QuantityPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public string[] Roles => [Admin, Write, OrderEMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderEMaterials"];

    public class CreateOrderEMaterialCommandHandler : IRequestHandler<CreateOrderEMaterialCommand, CreatedOrderEMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEMaterialRepository _orderEMaterialRepository;
        private readonly OrderEMaterialBusinessRules _orderEMaterialBusinessRules;

        public CreateOrderEMaterialCommandHandler(IMapper mapper, IOrderEMaterialRepository orderEMaterialRepository,
                                         OrderEMaterialBusinessRules orderEMaterialBusinessRules)
        {
            _mapper = mapper;
            _orderEMaterialRepository = orderEMaterialRepository;
            _orderEMaterialBusinessRules = orderEMaterialBusinessRules;
        }

        public async Task<CreatedOrderEMaterialResponse> Handle(CreateOrderEMaterialCommand request, CancellationToken cancellationToken)
        {
            OrderEMaterial orderEMaterial = _mapper.Map<OrderEMaterial>(request);

            await _orderEMaterialRepository.AddAsync(orderEMaterial);

            CreatedOrderEMaterialResponse response = _mapper.Map<CreatedOrderEMaterialResponse>(orderEMaterial);
            return response;
        }
    }
}