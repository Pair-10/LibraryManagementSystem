using Application.Features.Invoices.Constants;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommand : IRequest<UpdatedInvoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoicePrice { get; set; }
    public string InvoiceType { get; set; }
    public bool Status { get; set; }

    public string[] Roles => [Admin, Write, InvoicesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInvoices"];

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, UpdatedInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<UpdatedInvoiceResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);
            invoice = _mapper.Map(request, invoice);

            await _invoiceRepository.UpdateAsync(invoice!);

            UpdatedInvoiceResponse response = _mapper.Map<UpdatedInvoiceResponse>(invoice);
            return response;
        }
    }
}