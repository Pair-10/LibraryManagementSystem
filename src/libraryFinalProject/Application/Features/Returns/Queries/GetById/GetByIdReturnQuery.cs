using Application.Features.Returns.Constants;
using Application.Features.Returns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Returns.Constants.ReturnsOperationClaims;

namespace Application.Features.Returns.Queries.GetById;

public class GetByIdReturnQuery : IRequest<GetByIdReturnResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdReturnQueryHandler : IRequestHandler<GetByIdReturnQuery, GetByIdReturnResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReturnRepository _returnRepository;
        private readonly ReturnBusinessRules _returnBusinessRules;

        public GetByIdReturnQueryHandler(IMapper mapper, IReturnRepository returnRepository, ReturnBusinessRules returnBusinessRules)
        {
            _mapper = mapper;
            _returnRepository = returnRepository;
            _returnBusinessRules = returnBusinessRules;
        }

        public async Task<GetByIdReturnResponse> Handle(GetByIdReturnQuery request, CancellationToken cancellationToken)
        {
            Return? return = await _returnRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _returnBusinessRules.ReturnShouldExistWhenSelected(return);

            GetByIdReturnResponse response = _mapper.Map<GetByIdReturnResponse>(return);
            return response;
        }
    }
}