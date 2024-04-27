using Application.Features.Ematerials.Constants;
using Application.Features.Ematerials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ematerials.Constants.EmaterialsOperationClaims;

namespace Application.Features.Ematerials.Commands.Create;

public class CreateEmaterialCommand : IRequest<CreatedEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryTypeId { get; set; }
    public decimal Price { get; set; }
    public string PdfUrl { get; set; }

    public string[] Roles => [Admin, Write, EmaterialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterials"];

    public class CreateEmaterialCommandHandler : IRequestHandler<CreateEmaterialCommand, CreatedEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialRepository _ematerialRepository;
        private readonly EmaterialBusinessRules _ematerialBusinessRules;

        public CreateEmaterialCommandHandler(IMapper mapper, IEmaterialRepository ematerialRepository,
                                         EmaterialBusinessRules ematerialBusinessRules)
        {
            _mapper = mapper;
            _ematerialRepository = ematerialRepository;
            _ematerialBusinessRules = ematerialBusinessRules;
        }

        public async Task<CreatedEmaterialResponse> Handle(CreateEmaterialCommand request, CancellationToken cancellationToken)
        {
            await _ematerialBusinessRules.CategoryTypeIdShouldExist(request.CategoryTypeId, cancellationToken);
            Ematerial ematerial = _mapper.Map<Ematerial>(request);

            await _ematerialRepository.AddAsync(ematerial);

            CreatedEmaterialResponse response = _mapper.Map<CreatedEmaterialResponse>(ematerial);
            return response;
        }
    }
}