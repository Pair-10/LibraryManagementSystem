using Application.Features.EmaterialInvoices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.EmaterialInvoices.Constants.EmaterialInvoicesOperationClaims;

namespace Application.Features.EmaterialInvoices.Queries.GetList;

public class GetListEmaterialInvoiceQuery : IRequest<GetListResponse<GetListEmaterialInvoiceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListEmaterialInvoices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetEmaterialInvoices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEmaterialInvoiceQueryHandler : IRequestHandler<GetListEmaterialInvoiceQuery, GetListResponse<GetListEmaterialInvoiceListItemDto>>
    {
        private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
        private readonly IMapper _mapper;

        public GetListEmaterialInvoiceQueryHandler(IEmaterialInvoiceRepository ematerialInvoiceRepository, IMapper mapper)
        {
            _ematerialInvoiceRepository = ematerialInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEmaterialInvoiceListItemDto>> Handle(GetListEmaterialInvoiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EmaterialInvoice> ematerialInvoices = await _ematerialInvoiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEmaterialInvoiceListItemDto> response = _mapper.Map<GetListResponse<GetListEmaterialInvoiceListItemDto>>(ematerialInvoices);
            return response;
        }
    }
}