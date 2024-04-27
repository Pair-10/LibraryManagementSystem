using Application.Features.BasketEmaterials.Constants;
using Application.Features.BasketEmaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BasketEmaterials.Constants.BasketEmaterialsOperationClaims;

namespace Application.Features.BasketEmaterials.Queries.GetById;

public class GetByIdBasketEmaterialQuery : IRequest<GetByIdBasketEmaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBasketEmaterialQueryHandler : IRequestHandler<GetByIdBasketEmaterialQuery, GetByIdBasketEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBasketEmaterialRepository _basketEmaterialRepository;
        private readonly BasketEmaterialBusinessRules _basketEmaterialBusinessRules;

        public GetByIdBasketEmaterialQueryHandler(IMapper mapper, IBasketEmaterialRepository basketEmaterialRepository, BasketEmaterialBusinessRules basketEmaterialBusinessRules)
        {
            _mapper = mapper;
            _basketEmaterialRepository = basketEmaterialRepository;
            _basketEmaterialBusinessRules = basketEmaterialBusinessRules;
        }

        public async Task<GetByIdBasketEmaterialResponse> Handle(GetByIdBasketEmaterialQuery request, CancellationToken cancellationToken)
        {
            BasketEmaterial? basketEmaterial = await _basketEmaterialRepository.GetAsync(predicate: be => be.Id == request.Id, cancellationToken: cancellationToken);
            await _basketEmaterialBusinessRules.BasketEmaterialShouldExistWhenSelected(basketEmaterial);

            GetByIdBasketEmaterialResponse response = _mapper.Map<GetByIdBasketEmaterialResponse>(basketEmaterial);
            return response;
        }
    }
}