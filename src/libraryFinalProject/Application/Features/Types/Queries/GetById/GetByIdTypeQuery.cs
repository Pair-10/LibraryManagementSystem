using Application.Features.Types.Constants;
using Application.Features.Types.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Types.Constants.TypesOperationClaims;

namespace Application.Features.Types.Queries.GetById;

public class GetByIdTypeQuery : IRequest<GetByIdTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTypeQueryHandler : IRequestHandler<GetByIdTypeQuery, GetByIdTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;
        private readonly TypeBusinessRules _typeBusinessRules;

        public GetByIdTypeQueryHandler(IMapper mapper, ITypeRepository typeRepository, TypeBusinessRules typeBusinessRules)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<GetByIdTypeResponse> Handle(GetByIdTypeQuery request, CancellationToken cancellationToken)
        {
            Type? type = await _typeRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _typeBusinessRules.TypeShouldExistWhenSelected(type);

            GetByIdTypeResponse response = _mapper.Map<GetByIdTypeResponse>(type);
            return response;
        }
    }
}