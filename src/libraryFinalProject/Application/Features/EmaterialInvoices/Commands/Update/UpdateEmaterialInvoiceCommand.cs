using Application.Features.EmaterialInvoices.Constants;
using Application.Features.EmaterialInvoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.EmaterialInvoices.Constants.EmaterialInvoicesOperationClaims;

namespace Application.Features.EmaterialInvoices.Commands.Update;

public class UpdateEmaterialInvoiceCommand : IRequest<UpdatedEmaterialInvoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid InvoiceId { get; set; }
    public int Quantity { get; set; }
    public decimal QuantityPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentType { get; set; }

    public string[] Roles => [Admin, Write, EmaterialInvoicesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterialInvoices"];

    public class UpdateEmaterialInvoiceCommandHandler : IRequestHandler<UpdateEmaterialInvoiceCommand, UpdatedEmaterialInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
        private readonly EmaterialInvoiceBusinessRules _ematerialInvoiceBusinessRules;

        public UpdateEmaterialInvoiceCommandHandler(IMapper mapper, IEmaterialInvoiceRepository ematerialInvoiceRepository,
                                         EmaterialInvoiceBusinessRules ematerialInvoiceBusinessRules)
        {
            _mapper = mapper;
            _ematerialInvoiceRepository = ematerialInvoiceRepository;
            _ematerialInvoiceBusinessRules = ematerialInvoiceBusinessRules;
        }

        public async Task<UpdatedEmaterialInvoiceResponse> Handle(UpdateEmaterialInvoiceCommand request, CancellationToken cancellationToken)
        {
            EmaterialInvoice? ematerialInvoice = await _ematerialInvoiceRepository.GetAsync(predicate: ei => ei.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialInvoiceBusinessRules.EmaterialInvoiceShouldExistWhenSelected(ematerialInvoice);
            ematerialInvoice = _mapper.Map(request, ematerialInvoice);

            await _ematerialInvoiceRepository.UpdateAsync(ematerialInvoice!);

            UpdatedEmaterialInvoiceResponse response = _mapper.Map<UpdatedEmaterialInvoiceResponse>(ematerialInvoice);
            return response;
        }
    }
}