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

namespace Application.Features.EmaterialInvoices.Commands.Create;

public class CreateEmaterialInvoiceCommand : IRequest<CreatedEmaterialInvoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid EmaterialId { get; set; }
    public Guid InvoiceId { get; set; }
    public int Quantity { get; set; }
    public decimal QuantityPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentType { get; set; }

    public string[] Roles => [Admin, Write, EmaterialInvoicesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterialInvoices"];

    public class CreateEmaterialInvoiceCommandHandler : IRequestHandler<CreateEmaterialInvoiceCommand, CreatedEmaterialInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
        private readonly EmaterialInvoiceBusinessRules _ematerialInvoiceBusinessRules;

        public CreateEmaterialInvoiceCommandHandler(IMapper mapper, IEmaterialInvoiceRepository ematerialInvoiceRepository,
                                         EmaterialInvoiceBusinessRules ematerialInvoiceBusinessRules)
        {
            _mapper = mapper;
            _ematerialInvoiceRepository = ematerialInvoiceRepository;
            _ematerialInvoiceBusinessRules = ematerialInvoiceBusinessRules;
        }

        public async Task<CreatedEmaterialInvoiceResponse> Handle(CreateEmaterialInvoiceCommand request, CancellationToken cancellationToken)
        {
            EmaterialInvoice ematerialInvoice = _mapper.Map<EmaterialInvoice>(request);

            await _ematerialInvoiceRepository.AddAsync(ematerialInvoice);

            CreatedEmaterialInvoiceResponse response = _mapper.Map<CreatedEmaterialInvoiceResponse>(ematerialInvoice);
            return response;
        }
    }
}