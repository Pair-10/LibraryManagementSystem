using Application.Features.EmaterialInvoices.Constants;
using Application.Features.EmaterialInvoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.EmaterialInvoices.Constants.EmaterialInvoicesOperationClaims;

namespace Application.Features.EmaterialInvoices.Queries.GetById;

public class GetByIdEmaterialInvoiceQuery : IRequest<GetByIdEmaterialInvoiceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEmaterialInvoiceQueryHandler : IRequestHandler<GetByIdEmaterialInvoiceQuery, GetByIdEmaterialInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
        private readonly EmaterialInvoiceBusinessRules _ematerialInvoiceBusinessRules;

        public GetByIdEmaterialInvoiceQueryHandler(IMapper mapper, IEmaterialInvoiceRepository ematerialInvoiceRepository, EmaterialInvoiceBusinessRules ematerialInvoiceBusinessRules)
        {
            _mapper = mapper;
            _ematerialInvoiceRepository = ematerialInvoiceRepository;
            _ematerialInvoiceBusinessRules = ematerialInvoiceBusinessRules;
        }

        public async Task<GetByIdEmaterialInvoiceResponse> Handle(GetByIdEmaterialInvoiceQuery request, CancellationToken cancellationToken)
        {
            EmaterialInvoice? ematerialInvoice = await _ematerialInvoiceRepository.GetAsync(predicate: ei => ei.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialInvoiceBusinessRules.EmaterialInvoiceShouldExistWhenSelected(ematerialInvoice);

            GetByIdEmaterialInvoiceResponse response = _mapper.Map<GetByIdEmaterialInvoiceResponse>(ematerialInvoice);
            return response;
        }
    }
}