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

namespace Application.Features.PaymentTypes.Commands.Create;

public class CreatePaymentTypeCommand : IRequest<CreatedPaymentTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, PaymentTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPaymentTypes"];

    public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, CreatedPaymentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly PaymentTypeBusinessRules _paymentTypeBusinessRules;

        public CreatePaymentTypeCommandHandler(IMapper mapper, IPaymentTypeRepository paymentTypeRepository,
                                         PaymentTypeBusinessRules paymentTypeBusinessRules)
        {
            _mapper = mapper;
            _paymentTypeRepository = paymentTypeRepository;
            _paymentTypeBusinessRules = paymentTypeBusinessRules;
        }

        public async Task<CreatedPaymentTypeResponse> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            PaymentType paymentType = _mapper.Map<PaymentType>(request);

            await _paymentTypeRepository.AddAsync(paymentType);

            CreatedPaymentTypeResponse response = _mapper.Map<CreatedPaymentTypeResponse>(paymentType);
            return response;
        }
    }
}