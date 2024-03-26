using Application.Features.Returneds.Constants;
using Application.Features.Returneds.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Returneds.Constants.ReturnedsOperationClaims;

namespace Application.Features.Returneds.Queries.GetById;

public class GetByIdReturnedQuery : IRequest<GetByIdReturnedResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdReturnedQueryHandler : IRequestHandler<GetByIdReturnedQuery, GetByIdReturnedResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnedRepository _returnedRepository;
        private readonly ReturnedBusinessRules _returnedBusinessRules;

        public GetByIdReturnedQueryHandler(IMapper mapper, IReturnedRepository returnedRepository, ReturnedBusinessRules returnedBusinessRules)
        {
            _mapper = mapper;
            _returnedRepository = returnedRepository;
            _returnedBusinessRules = returnedBusinessRules;
        }

        public async Task<GetByIdReturnedResponse> Handle(GetByIdReturnedQuery request, CancellationToken cancellationToken)
        {
            Returned? returned = await _returnedRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnedBusinessRules.ReturnedShouldExistWhenSelected(returned);

            GetByIdReturnedResponse response = _mapper.Map<GetByIdReturnedResponse>(returned);
            return response;
        }
    }
}