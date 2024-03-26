using Application.Features.Articles.Constants;
using Application.Features.Articles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Articles.Constants.ArticlesOperationClaims;

namespace Application.Features.Articles.Commands.Create;

public class CreateArticleCommand : IRequest<CreatedArticleResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryId { get; set; }
    public string PublictionName { get; set; }

    public string[] Roles => [Admin, Write, ArticlesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetArticles"];

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreatedArticleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleBusinessRules _articleBusinessRules;

        public CreateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository,
                                         ArticleBusinessRules articleBusinessRules)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _articleBusinessRules = articleBusinessRules;
        }

        public async Task<CreatedArticleResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article article = _mapper.Map<Article>(request);

            await _articleRepository.AddAsync(article);

            CreatedArticleResponse response = _mapper.Map<CreatedArticleResponse>(article);
            return response;
        }
    }
}