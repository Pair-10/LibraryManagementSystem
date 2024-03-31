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
using Application.Features.Activities.Rules;

namespace Application.Features.BasketEmaterials.Commands.Create;

public class CreateBasketEmaterialCommand : IRequest<CreatedBasketEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }

    public string[] Roles => [Admin, Write, BasketEmaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBasketEmaterials"];

    public class CreateBasketEmaterialCommandHandler : IRequestHandler<CreateBasketEmaterialCommand, CreatedBasketEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBasketEmaterialRepository _basketEmaterialRepository;
        private readonly BasketEmaterialBusinessRules _basketEmaterialBusinessRules;

        public CreateBasketEmaterialCommandHandler(IMapper mapper, IBasketEmaterialRepository basketEmaterialRepository,
                                         BasketEmaterialBusinessRules basketEmaterialBusinessRules)
        {
            _mapper = mapper;
            _basketEmaterialRepository = basketEmaterialRepository;
            _basketEmaterialBusinessRules = basketEmaterialBusinessRules;
        }

        public async Task<CreatedBasketEmaterialResponse> Handle(CreateBasketEmaterialCommand request, CancellationToken cancellationToken)
        {
          
            BasketEmaterial basketEmaterial = _mapper.Map<BasketEmaterial>(request);

            await _basketEmaterialRepository.AddAsync(basketEmaterial);

            CreatedBasketEmaterialResponse response = _mapper.Map<CreatedBasketEmaterialResponse>(basketEmaterial);
            return response;
        }
    }
}