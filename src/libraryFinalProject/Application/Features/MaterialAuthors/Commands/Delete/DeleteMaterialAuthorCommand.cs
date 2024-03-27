using Application.Features.MaterialAuthors.Constants;
using Application.Features.MaterialAuthors.Constants;
using Application.Features.MaterialAuthors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MaterialAuthors.Constants.MaterialAuthorsOperationClaims;

namespace Application.Features.MaterialAuthors.Commands.Delete;

public class DeleteMaterialAuthorCommand : IRequest<DeletedMaterialAuthorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MaterialAuthorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAuthors"];

    public class DeleteMaterialAuthorCommandHandler : IRequestHandler<DeleteMaterialAuthorCommand, DeletedMaterialAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAuthorRepository _materialAuthorRepository;
        private readonly MaterialAuthorBusinessRules _materialAuthorBusinessRules;

        public DeleteMaterialAuthorCommandHandler(IMapper mapper, IMaterialAuthorRepository materialAuthorRepository,
                                         MaterialAuthorBusinessRules materialAuthorBusinessRules)
        {
            _mapper = mapper;
            _materialAuthorRepository = materialAuthorRepository;
            _materialAuthorBusinessRules = materialAuthorBusinessRules;
        }

        public async Task<DeletedMaterialAuthorResponse> Handle(DeleteMaterialAuthorCommand request, CancellationToken cancellationToken)
        {
            MaterialAuthor? materialAuthor = await _materialAuthorRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAuthorBusinessRules.MaterialAuthorShouldExistWhenSelected(materialAuthor);

            await _materialAuthorRepository.DeleteAsync(materialAuthor!);

            DeletedMaterialAuthorResponse response = _mapper.Map<DeletedMaterialAuthorResponse>(materialAuthor);
            return response;
        }
    }
}