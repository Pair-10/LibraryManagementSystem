using Application.Features.Magazines.Constants;
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

namespace Application.Features.Magazines.Commands.Delete;

public class DeleteMagazineCommand : IRequest<DeletedMagazineResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MagazinesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMagazines"];

    public class DeleteMagazineCommandHandler : IRequestHandler<DeleteMagazineCommand, DeletedMagazineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMagazineRepository _magazineRepository;
        private readonly MagazineBusinessRules _magazineBusinessRules;

        public DeleteMagazineCommandHandler(IMapper mapper, IMagazineRepository magazineRepository,
                                         MagazineBusinessRules magazineBusinessRules)
        {
            _mapper = mapper;
            _magazineRepository = magazineRepository;
            _magazineBusinessRules = magazineBusinessRules;
        }

        public async Task<DeletedMagazineResponse> Handle(DeleteMagazineCommand request, CancellationToken cancellationToken)
        {
            Magazine? magazine = await _magazineRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _magazineBusinessRules.MagazineShouldExistWhenSelected(magazine);

            await _magazineRepository.DeleteAsync(magazine!);

            DeletedMagazineResponse response = _mapper.Map<DeletedMagazineResponse>(magazine);
            return response;
        }
    }
}