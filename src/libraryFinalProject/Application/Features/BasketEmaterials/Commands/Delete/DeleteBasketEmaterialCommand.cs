using Application.Features.BasketEmaterials.Constants;
using Application.Features.BasketEmaterials.Constants;
using Application.Features.BasketEmaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BasketEmaterials.Constants.BasketEmaterialsOperationClaims;

namespace Application.Features.BasketEmaterials.Commands.Delete;

public class DeleteBasketEmaterialCommand : IRequest<DeletedBasketEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BasketEmaterialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBasketEmaterials"];

    public class DeleteBasketEmaterialCommandHandler : IRequestHandler<DeleteBasketEmaterialCommand, DeletedBasketEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBasketEmaterialRepository _basketEmaterialRepository;
        private readonly BasketEmaterialBusinessRules _basketEmaterialBusinessRules;

        public DeleteBasketEmaterialCommandHandler(IMapper mapper, IBasketEmaterialRepository basketEmaterialRepository,
                                         BasketEmaterialBusinessRules basketEmaterialBusinessRules)
        {
            _mapper = mapper;
            _basketEmaterialRepository = basketEmaterialRepository;
            _basketEmaterialBusinessRules = basketEmaterialBusinessRules;
        }

        public async Task<DeletedBasketEmaterialResponse> Handle(DeleteBasketEmaterialCommand request, CancellationToken cancellationToken)
        {
            BasketEmaterial? basketEmaterial = await _basketEmaterialRepository.GetAsync(predicate: be => be.Id == request.Id, cancellationToken: cancellationToken);
            await _basketEmaterialBusinessRules.BasketEmaterialShouldExistWhenSelected(basketEmaterial);

            await _basketEmaterialRepository.DeleteAsync(basketEmaterial!);

            DeletedBasketEmaterialResponse response = _mapper.Map<DeletedBasketEmaterialResponse>(basketEmaterial);
            return response;
        }
    }
}