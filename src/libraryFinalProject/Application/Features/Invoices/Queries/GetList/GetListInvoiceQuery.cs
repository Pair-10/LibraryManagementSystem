using Application.Features.Invoices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Queries.GetList;

public class GetListInvoiceQuery : IRequest<GetListResponse<GetListInvoiceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListInvoices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetInvoices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInvoiceQueryHandler : IRequestHandler<GetListInvoiceQuery, GetListResponse<GetListInvoiceListItemDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetListInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInvoiceListItemDto>> Handle(GetListInvoiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Invoice> invoices = await _invoiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInvoiceListItemDto> response = _mapper.Map<GetListResponse<GetListInvoiceListItemDto>>(invoices);
            return response;
        }
    }
}