using Application.Features.PaymentTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PaymentTypes.Constants.PaymentTypesOperationClaims;

namespace Application.Features.PaymentTypes.Queries.GetList;

public class GetListPaymentTypeQuery : IRequest<GetListResponse<GetListPaymentTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPaymentTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPaymentTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPaymentTypeQueryHandler : IRequestHandler<GetListPaymentTypeQuery, GetListResponse<GetListPaymentTypeListItemDto>>
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;

        public GetListPaymentTypeQueryHandler(IPaymentTypeRepository paymentTypeRepository, IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPaymentTypeListItemDto>> Handle(GetListPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentType> paymentTypes = await _paymentTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPaymentTypeListItemDto> response = _mapper.Map<GetListResponse<GetListPaymentTypeListItemDto>>(paymentTypes);
            return response;
        }
    }
}