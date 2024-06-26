using Application.Features.BorrowedMaterials.Constants;
using Application.Features.BorrowedMaterials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BorrowedMaterials.Constants.BorrowedMaterialsOperationClaims;
using Application.Features.Baskets.Rules;


namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommand : IRequest<CreatedBorrowedMaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Deadline { get; set; }

    public string[] Roles => [Admin, Write, BorrowedMaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBorrowedMaterials"];

    public class CreateBorrowedMaterialCommandHandler : IRequestHandler<CreateBorrowedMaterialCommand, CreatedBorrowedMaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBorrowedMaterialRepository _borrowedMaterialRepository;
        private readonly BorrowedMaterialBusinessRules _borrowedMaterialBusinessRules;

        public CreateBorrowedMaterialCommandHandler(IMapper mapper, IBorrowedMaterialRepository borrowedMaterialRepository,
                                         BorrowedMaterialBusinessRules borrowedMaterialBusinessRules)
        {
            _mapper = mapper;
            _borrowedMaterialRepository = borrowedMaterialRepository;
            _borrowedMaterialBusinessRules = borrowedMaterialBusinessRules;
        }

        public async Task<CreatedBorrowedMaterialResponse> Handle(CreateBorrowedMaterialCommand request, CancellationToken cancellationToken)
        {
            await _borrowedMaterialBusinessRules.UserShouldExist(request.UserId);//userid kontrolu bussiines classından al
            await _borrowedMaterialBusinessRules.MaterialQuantityShouldGreaterThenZero(request.MaterialId, request.UserId);
            await _borrowedMaterialBusinessRules.MaterialShouldExist(request.MaterialId);//materialid kontrolu bussiines classından al
            Task<bool> isZero = _borrowedMaterialBusinessRules.MaterialQuantityShouldGreaterThenZero(request.MaterialId, request.UserId);
            BorrowedMaterial borrowedMaterial = _mapper.Map<BorrowedMaterial>(request);

            if(isZero.Result == false)
            {
               await _borrowedMaterialRepository.AddAsync(borrowedMaterial);
            }
            
            CreatedBorrowedMaterialResponse response = _mapper.Map<CreatedBorrowedMaterialResponse>(borrowedMaterial);
            return response;
        }
    }
}