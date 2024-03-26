using Application.Features.Invoices.Constants;
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

namespace Application.Features.Invoices.Commands.Delete;

public class DeleteInvoiceCommand : IRequest<DeletedInvoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, InvoicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInvoices"];

    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeletedInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public DeleteInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<DeletedInvoiceResponse> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

            await _invoiceRepository.DeleteAsync(invoice!);

            DeletedInvoiceResponse response = _mapper.Map<DeletedInvoiceResponse>(invoice);
            return response;
        }
    }
}