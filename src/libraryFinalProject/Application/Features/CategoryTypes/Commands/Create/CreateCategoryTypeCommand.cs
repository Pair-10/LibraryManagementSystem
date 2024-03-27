using Application.Features.CategoryTypes.Constants;
using Application.Features.CategoryTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.CategoryTypes.Constants.CategoryTypesOperationClaims;

namespace Application.Features.CategoryTypes.Commands.Create;

public class CreateCategoryTypeCommand : IRequest<CreatedCategoryTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid MaterialTypeId { get; set; }

    public string[] Roles => [Admin, Write, CategoryTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCategoryTypes"];

    public class CreateCategoryTypeCommandHandler : IRequestHandler<CreateCategoryTypeCommand, CreatedCategoryTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly CategoryTypeBusinessRules _categoryTypeBusinessRules;

        public CreateCategoryTypeCommandHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository,
                                         CategoryTypeBusinessRules categoryTypeBusinessRules)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
            _categoryTypeBusinessRules = categoryTypeBusinessRules;
        }

        public async Task<CreatedCategoryTypeResponse> Handle(CreateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            CategoryType categoryType = _mapper.Map<CategoryType>(request);

            await _categoryTypeRepository.AddAsync(categoryType);

            CreatedCategoryTypeResponse response = _mapper.Map<CreatedCategoryTypeResponse>(categoryType);
            return response;
        }
    }
}