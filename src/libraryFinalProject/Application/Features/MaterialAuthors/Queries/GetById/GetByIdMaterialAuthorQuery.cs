using Application.Features.MaterialAuthors.Constants;
using Application.Features.MaterialAuthors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaterialAuthors.Constants.MaterialAuthorsOperationClaims;

namespace Application.Features.MaterialAuthors.Queries.GetById;

public class GetByIdMaterialAuthorQuery : IRequest<GetByIdMaterialAuthorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaterialAuthorQueryHandler : IRequestHandler<GetByIdMaterialAuthorQuery, GetByIdMaterialAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAuthorRepository _materialAuthorRepository;
        private readonly MaterialAuthorBusinessRules _materialAuthorBusinessRules;

        public GetByIdMaterialAuthorQueryHandler(IMapper mapper, IMaterialAuthorRepository materialAuthorRepository, MaterialAuthorBusinessRules materialAuthorBusinessRules)
        {
            _mapper = mapper;
            _materialAuthorRepository = materialAuthorRepository;
            _materialAuthorBusinessRules = materialAuthorBusinessRules;
        }

        public async Task<GetByIdMaterialAuthorResponse> Handle(GetByIdMaterialAuthorQuery request, CancellationToken cancellationToken)
        {
            MaterialAuthor? materialAuthor = await _materialAuthorRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAuthorBusinessRules.MaterialAuthorShouldExistWhenSelected(materialAuthor);

            GetByIdMaterialAuthorResponse response = _mapper.Map<GetByIdMaterialAuthorResponse>(materialAuthor);
            return response;
        }
    }
}