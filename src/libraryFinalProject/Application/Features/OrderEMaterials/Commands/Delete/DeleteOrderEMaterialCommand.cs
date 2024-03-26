using Application.Features.OrderEMaterials.Constants;
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

namespace Application.Features.OrderEMaterials.Commands.Delete;

public class DeleteOrderEMaterialCommand : IRequest<DeletedOrderEMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, OrderEMaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderEMaterials"];

    public class DeleteOrderEMaterialCommandHandler : IRequestHandler<DeleteOrderEMaterialCommand, DeletedOrderEMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEMaterialRepository _orderEMaterialRepository;
        private readonly OrderEMaterialBusinessRules _orderEMaterialBusinessRules;

        public DeleteOrderEMaterialCommandHandler(IMapper mapper, IOrderEMaterialRepository orderEMaterialRepository,
                                         OrderEMaterialBusinessRules orderEMaterialBusinessRules)
        {
            _mapper = mapper;
            _orderEMaterialRepository = orderEMaterialRepository;
            _orderEMaterialBusinessRules = orderEMaterialBusinessRules;
        }

        public async Task<DeletedOrderEMaterialResponse> Handle(DeleteOrderEMaterialCommand request, CancellationToken cancellationToken)
        {
            OrderEMaterial? orderEMaterial = await _orderEMaterialRepository.GetAsync(predicate: oem => oem.Id == request.Id, cancellationToken: cancellationToken);
            await _orderEMaterialBusinessRules.OrderEMaterialShouldExistWhenSelected(orderEMaterial);

            await _orderEMaterialRepository.DeleteAsync(orderEMaterial!);

            DeletedOrderEMaterialResponse response = _mapper.Map<DeletedOrderEMaterialResponse>(orderEMaterial);
            return response;
        }
    }
}