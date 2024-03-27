using Application.Features.PaymentTypes.Constants;
using Application.Features.PaymentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PaymentTypes.Constants.PaymentTypesOperationClaims;

namespace Application.Features.PaymentTypes.Queries.GetById;

public class GetByIdPaymentTypeQuery : IRequest<GetByIdPaymentTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPaymentTypeQueryHandler : IRequestHandler<GetByIdPaymentTypeQuery, GetByIdPaymentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly PaymentTypeBusinessRules _paymentTypeBusinessRules;

        public GetByIdPaymentTypeQueryHandler(IMapper mapper, IPaymentTypeRepository paymentTypeRepository, PaymentTypeBusinessRules paymentTypeBusinessRules)
        {
            _mapper = mapper;
            _paymentTypeRepository = paymentTypeRepository;
            _paymentTypeBusinessRules = paymentTypeBusinessRules;
        }

        public async Task<GetByIdPaymentTypeResponse> Handle(GetByIdPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            PaymentType? paymentType = await _paymentTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentTypeBusinessRules.PaymentTypeShouldExistWhenSelected(paymentType);

            GetByIdPaymentTypeResponse response = _mapper.Map<GetByIdPaymentTypeResponse>(paymentType);
            return response;
        }
    }
}