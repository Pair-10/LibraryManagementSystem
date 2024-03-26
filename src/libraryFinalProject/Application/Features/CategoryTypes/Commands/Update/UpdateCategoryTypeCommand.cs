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

namespace Application.Features.CategoryTypes.Commands.Update;

public class UpdateCategoryTypeCommand : IRequest<UpdatedCategoryTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TypeId { get; set; }

    public string[] Roles => [Admin, Write, CategoryTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCategoryTypes"];

    public class UpdateCategoryTypeCommandHandler : IRequestHandler<UpdateCategoryTypeCommand, UpdatedCategoryTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly CategoryTypeBusinessRules _categoryTypeBusinessRules;

        public UpdateCategoryTypeCommandHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository,
                                         CategoryTypeBusinessRules categoryTypeBusinessRules)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
            _categoryTypeBusinessRules = categoryTypeBusinessRules;
        }

        public async Task<UpdatedCategoryTypeResponse> Handle(UpdateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            CategoryType? categoryType = await _categoryTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTypeBusinessRules.CategoryTypeShouldExistWhenSelected(categoryType);
            categoryType = _mapper.Map(request, categoryType);

            await _categoryTypeRepository.UpdateAsync(categoryType!);

            UpdatedCategoryTypeResponse response = _mapper.Map<UpdatedCategoryTypeResponse>(categoryType);
            return response;
        }
    }
}