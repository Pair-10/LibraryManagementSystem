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

namespace Application.Features.BasketEmaterials.Commands.Update;

public class UpdateBasketEmaterialCommand : IRequest<UpdatedBasketEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }

    public string[] Roles => [Admin, Write, BasketEmaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBasketEmaterials"];

    public class UpdateBasketEmaterialCommandHandler : IRequestHandler<UpdateBasketEmaterialCommand, UpdatedBasketEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBasketEmaterialRepository _basketEmaterialRepository;
        private readonly BasketEmaterialBusinessRules _basketEmaterialBusinessRules;

        public UpdateBasketEmaterialCommandHandler(IMapper mapper, IBasketEmaterialRepository basketEmaterialRepository,
                                         BasketEmaterialBusinessRules basketEmaterialBusinessRules)
        {
            _mapper = mapper;
            _basketEmaterialRepository = basketEmaterialRepository;
            _basketEmaterialBusinessRules = basketEmaterialBusinessRules;
        }

        public async Task<UpdatedBasketEmaterialResponse> Handle(UpdateBasketEmaterialCommand request, CancellationToken cancellationToken)
        {
            await _basketEmaterialBusinessRules.BasketEmaterialShouldExist(request.BasketId);//basketid kontrolü bussiines classýndan al
            await _basketEmaterialBusinessRules.BasketematerialShouldExist(request.EmaterialId);//ematerialid kontrolü bussiines classýndan al
            BasketEmaterial? basketEmaterial = await _basketEmaterialRepository.GetAsync(predicate: be => be.Id == request.Id, cancellationToken: cancellationToken);
            await _basketEmaterialBusinessRules.BasketEmaterialShouldExistWhenSelected(basketEmaterial);
            basketEmaterial = _mapper.Map(request, basketEmaterial);

            await _basketEmaterialRepository.UpdateAsync(basketEmaterial!);

            UpdatedBasketEmaterialResponse response = _mapper.Map<UpdatedBasketEmaterialResponse>(basketEmaterial);
            return response;
        }
    }
}