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

namespace Application.Features.MaterialAuthors.Commands.Update;

public class UpdateMaterialAuthorCommand : IRequest<UpdatedMaterialAuthorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }

    public string[] Roles => [Admin, Write, MaterialAuthorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAuthors"];

    public class UpdateMaterialAuthorCommandHandler : IRequestHandler<UpdateMaterialAuthorCommand, UpdatedMaterialAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAuthorRepository _materialAuthorRepository;
        private readonly MaterialAuthorBusinessRules _materialAuthorBusinessRules;

        public UpdateMaterialAuthorCommandHandler(IMapper mapper, IMaterialAuthorRepository materialAuthorRepository,
                                         MaterialAuthorBusinessRules materialAuthorBusinessRules)
        {
            _mapper = mapper;
            _materialAuthorRepository = materialAuthorRepository;
            _materialAuthorBusinessRules = materialAuthorBusinessRules;
        }

        public async Task<UpdatedMaterialAuthorResponse> Handle(UpdateMaterialAuthorCommand request, CancellationToken cancellationToken)
        {
            MaterialAuthor? materialAuthor = await _materialAuthorRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _materialAuthorBusinessRules.MaterialAuthorShouldExistWhenSelected(materialAuthor);
            materialAuthor = _mapper.Map(request, materialAuthor);

            await _materialAuthorRepository.UpdateAsync(materialAuthor!);

            UpdatedMaterialAuthorResponse response = _mapper.Map<UpdatedMaterialAuthorResponse>(materialAuthor);
            return response;
        }
    }
}