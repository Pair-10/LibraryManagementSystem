using Application.Features.Ematerials.Constants;
using Application.Features.Ematerials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ematerials.Constants.EmaterialsOperationClaims;

namespace Application.Features.Ematerials.Queries.GetById;

public class GetByIdEmaterialQuery : IRequest<GetByIdEmaterialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEmaterialQueryHandler : IRequestHandler<GetByIdEmaterialQuery, GetByIdEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialRepository _ematerialRepository;
        private readonly EmaterialBusinessRules _ematerialBusinessRules;

        public GetByIdEmaterialQueryHandler(IMapper mapper, IEmaterialRepository ematerialRepository, EmaterialBusinessRules ematerialBusinessRules)
        {
            _mapper = mapper;
            _ematerialRepository = ematerialRepository;
            _ematerialBusinessRules = ematerialBusinessRules;
        }

        public async Task<GetByIdEmaterialResponse> Handle(GetByIdEmaterialQuery request, CancellationToken cancellationToken)
        {
            Ematerial? ematerial = await _ematerialRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialBusinessRules.EmaterialShouldExistWhenSelected(ematerial);

            GetByIdEmaterialResponse response = _mapper.Map<GetByIdEmaterialResponse>(ematerial);
            return response;
        }
    }
}