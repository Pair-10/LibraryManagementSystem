using Application.Features.CategoryTypes.Constants;
using Application.Features.CategoryTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CategoryTypes.Constants.CategoryTypesOperationClaims;

namespace Application.Features.CategoryTypes.Queries.GetById;

public class GetByIdCategoryTypeQuery : IRequest<GetByIdCategoryTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCategoryTypeQueryHandler : IRequestHandler<GetByIdCategoryTypeQuery, GetByIdCategoryTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly CategoryTypeBusinessRules _categoryTypeBusinessRules;

        public GetByIdCategoryTypeQueryHandler(IMapper mapper, ICategoryTypeRepository categoryTypeRepository, CategoryTypeBusinessRules categoryTypeBusinessRules)
        {
            _mapper = mapper;
            _categoryTypeRepository = categoryTypeRepository;
            _categoryTypeBusinessRules = categoryTypeBusinessRules;
        }

        public async Task<GetByIdCategoryTypeResponse> Handle(GetByIdCategoryTypeQuery request, CancellationToken cancellationToken)
        {
            CategoryType? categoryType = await _categoryTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryTypeBusinessRules.CategoryTypeShouldExistWhenSelected(categoryType);

            GetByIdCategoryTypeResponse response = _mapper.Map<GetByIdCategoryTypeResponse>(categoryType);
            return response;
        }
    }
}