using Application.Features.EmaterialInvoices.Constants;
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

namespace Application.Features.EmaterialInvoices.Commands.Delete;

public class DeleteEmaterialInvoiceCommand : IRequest<DeletedEmaterialInvoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, EmaterialInvoicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterialInvoices"];

    public class DeleteEmaterialInvoiceCommandHandler : IRequestHandler<DeleteEmaterialInvoiceCommand, DeletedEmaterialInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialInvoiceRepository _ematerialInvoiceRepository;
        private readonly EmaterialInvoiceBusinessRules _ematerialInvoiceBusinessRules;

        public DeleteEmaterialInvoiceCommandHandler(IMapper mapper, IEmaterialInvoiceRepository ematerialInvoiceRepository,
                                         EmaterialInvoiceBusinessRules ematerialInvoiceBusinessRules)
        {
            _mapper = mapper;
            _ematerialInvoiceRepository = ematerialInvoiceRepository;
            _ematerialInvoiceBusinessRules = ematerialInvoiceBusinessRules;
        }

        public async Task<DeletedEmaterialInvoiceResponse> Handle(DeleteEmaterialInvoiceCommand request, CancellationToken cancellationToken)
        {
            EmaterialInvoice? ematerialInvoice = await _ematerialInvoiceRepository.GetAsync(predicate: ei => ei.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialInvoiceBusinessRules.EmaterialInvoiceShouldExistWhenSelected(ematerialInvoice);

            await _ematerialInvoiceRepository.DeleteAsync(ematerialInvoice!);

            DeletedEmaterialInvoiceResponse response = _mapper.Map<DeletedEmaterialInvoiceResponse>(ematerialInvoice);
            return response;
        }
    }
}