using Application.Features.PaymentTypes.Constants;
using Application.Features.PaymentTypes.Constants;
using Application.Features.PaymentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PaymentTypes.Constants.PaymentTypesOperationClaims;

namespace Application.Features.PaymentTypes.Commands.Delete;

public class DeletePaymentTypeCommand : IRequest<DeletedPaymentTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PaymentTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPaymentTypes"];

    public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand, DeletedPaymentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly PaymentTypeBusinessRules _paymentTypeBusinessRules;

        public DeletePaymentTypeCommandHandler(IMapper mapper, IPaymentTypeRepository paymentTypeRepository,
                                         PaymentTypeBusinessRules paymentTypeBusinessRules)
        {
            _mapper = mapper;
            _paymentTypeRepository = paymentTypeRepository;
            _paymentTypeBusinessRules = paymentTypeBusinessRules;
        }

        public async Task<DeletedPaymentTypeResponse> Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            PaymentType? paymentType = await _paymentTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentTypeBusinessRules.PaymentTypeShouldExistWhenSelected(paymentType);

            await _paymentTypeRepository.DeleteAsync(paymentType!);

            DeletedPaymentTypeResponse response = _mapper.Map<DeletedPaymentTypeResponse>(paymentType);
            return response;
        }
    }
}