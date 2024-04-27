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

namespace Application.Features.Ematerials.Commands.Update;

public class UpdateEmaterialCommand : IRequest<UpdatedEmaterialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CategoryTypeId { get; set; }
    public decimal Price { get; set; }
    public string PdfUrl { get; set; }

    public string[] Roles => [Admin, Write, EmaterialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmaterials"];

    public class UpdateEmaterialCommandHandler : IRequestHandler<UpdateEmaterialCommand, UpdatedEmaterialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmaterialRepository _ematerialRepository;
        private readonly EmaterialBusinessRules _ematerialBusinessRules;

        public UpdateEmaterialCommandHandler(IMapper mapper, IEmaterialRepository ematerialRepository,
                                         EmaterialBusinessRules ematerialBusinessRules)
        {
            _mapper = mapper;
            _ematerialRepository = ematerialRepository;
            _ematerialBusinessRules = ematerialBusinessRules;
        }

        public async Task<UpdatedEmaterialResponse> Handle(UpdateEmaterialCommand request, CancellationToken cancellationToken)
        {
            await _ematerialBusinessRules.CategoryTypeIdShouldExist(request.CategoryTypeId, cancellationToken);
            Ematerial? ematerial = await _ematerialRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _ematerialBusinessRules.EmaterialShouldExistWhenSelected(ematerial);
            ematerial = _mapper.Map(request, ematerial);

            await _ematerialRepository.UpdateAsync(ematerial!);

            UpdatedEmaterialResponse response = _mapper.Map<UpdatedEmaterialResponse>(ematerial);
            return response;
        }
    }
}