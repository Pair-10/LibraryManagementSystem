using Application.Features.Magazines.Constants;
using Application.Features.Magazines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Magazines.Constants.MagazinesOperationClaims;

namespace Application.Features.Magazines.Commands.Create;

public class CreateMagazineCommand : IRequest<CreatedMagazineResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }
    public Guid MaterialId { get; set; }
    public string[] Roles => [Admin, Write, MagazinesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMagazines"];

    public class CreateMagazineCommandHandler : IRequestHandler<CreateMagazineCommand, CreatedMagazineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMagazineRepository _magazineRepository;
        private readonly MagazineBusinessRules _magazineBusinessRules;

        public CreateMagazineCommandHandler(IMapper mapper, IMagazineRepository magazineRepository,
                                         MagazineBusinessRules magazineBusinessRules)
        {
            _mapper = mapper;
            _magazineRepository = magazineRepository;
            _magazineBusinessRules = magazineBusinessRules;
        }

        public async Task<CreatedMagazineResponse> Handle(CreateMagazineCommand request, CancellationToken cancellationToken)
        {
            await _magazineBusinessRules.MagazineISSNShouldExistWhenSelected(request.ISSN,cancellationToken);
            await _magazineBusinessRules.CategoryIdShouldExistWhenSelected(request.CategoryId,cancellationToken);

            Magazine magazine = _mapper.Map<Magazine>(request);

            await _magazineRepository.AddAsync(magazine);

            CreatedMagazineResponse response = _mapper.Map<CreatedMagazineResponse>(magazine);
            return response;
        }
    }
}