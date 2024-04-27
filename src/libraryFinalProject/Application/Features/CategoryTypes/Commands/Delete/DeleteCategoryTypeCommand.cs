using Application.Features.CategoryTypes.Constants;
using Application.Features.CategoryTypes.Constants;
using Application.Features.CategoryTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CategoryTypes.Constants.CategoryTypesOperationClaims;

namespace Application.Features.CategoryTypes.Commands.Delete;

public class DeleteCategoryTypeCommand : IRequest<DeletedCategoryTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CategoryTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCategoryTypes"];

    public class DeleteCategoryTypeCommandHandler : IRequestHandler<DeleteCategoryTypeCommand, DeletedCategoryTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly CategoryTypeBusinessRules _categoryTypeBusinessRules;

        public DeleteCategoryTypeCommandHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository,
                                         CategoryTypeBusinessRules categoryTypeBusinessRules)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
            _categoryTypeBusinessRules = categoryTypeBusinessRules;
        }

        public async Task<DeletedCategoryTypeResponse> Handle(DeleteCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            CategoryType? categoryType = await _categoryTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTypeBusinessRules.CategoryTypeShouldExistWhenSelected(categoryType);

            await _categoryTypeRepository.DeleteAsync(categoryType!);

            DeletedCategoryTypeResponse response = _mapper.Map<DeletedCategoryTypeResponse>(categoryType);
            return response;
        }
    }
}