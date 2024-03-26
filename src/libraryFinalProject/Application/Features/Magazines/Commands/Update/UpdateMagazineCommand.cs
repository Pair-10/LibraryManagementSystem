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

namespace Application.Features.Magazines.Commands.Update;

public class UpdateMagazineCommand : IRequest<UpdatedMagazineResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISSN { get; set; }
    public string Issue { get; set; }

    public string[] Roles => [Admin, Write, MagazinesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMagazines"];

    public class UpdateMagazineCommandHandler : IRequestHandler<UpdateMagazineCommand, UpdatedMagazineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMagazineRepository _magazineRepository;
        private readonly MagazineBusinessRules _magazineBusinessRules;

        public UpdateMagazineCommandHandler(IMapper mapper, IMagazineRepository magazineRepository,
                                         MagazineBusinessRules magazineBusinessRules)
        {
            _mapper = mapper;
            _magazineRepository = magazineRepository;
            _magazineBusinessRules = magazineBusinessRules;
        }

        public async Task<UpdatedMagazineResponse> Handle(UpdateMagazineCommand request, CancellationToken cancellationToken)
        {
            Magazine? magazine = await _magazineRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _magazineBusinessRules.MagazineShouldExistWhenSelected(magazine);
            magazine = _mapper.Map(request, magazine);

            await _magazineRepository.UpdateAsync(magazine!);

            UpdatedMagazineResponse response = _mapper.Map<UpdatedMagazineResponse>(magazine);
            return response;
        }
    }
}