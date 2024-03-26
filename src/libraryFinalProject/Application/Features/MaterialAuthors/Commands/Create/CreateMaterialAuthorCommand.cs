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

namespace Application.Features.MaterialAuthors.Commands.Create;

public class CreateMaterialAuthorCommand : IRequest<CreatedMaterialAuthorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }

    public string[] Roles => [Admin, Write, MaterialAuthorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMaterialAuthors"];

    public class CreateMaterialAuthorCommandHandler : IRequestHandler<CreateMaterialAuthorCommand, CreatedMaterialAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialAuthorRepository _materialAuthorRepository;
        private readonly MaterialAuthorBusinessRules _materialAuthorBusinessRules;

        public CreateMaterialAuthorCommandHandler(IMapper mapper, IMaterialAuthorRepository materialAuthorRepository,
                                         MaterialAuthorBusinessRules materialAuthorBusinessRules)
        {
            _mapper = mapper;
            _materialAuthorRepository = materialAuthorRepository;
            _materialAuthorBusinessRules = materialAuthorBusinessRules;
        }

        public async Task<CreatedMaterialAuthorResponse> Handle(CreateMaterialAuthorCommand request, CancellationToken cancellationToken)
        {
            MaterialAuthor materialAuthor = _mapper.Map<MaterialAuthor>(request);

            await _materialAuthorRepository.AddAsync(materialAuthor);

            CreatedMaterialAuthorResponse response = _mapper.Map<CreatedMaterialAuthorResponse>(materialAuthor);
            return response;
        }
    }
}