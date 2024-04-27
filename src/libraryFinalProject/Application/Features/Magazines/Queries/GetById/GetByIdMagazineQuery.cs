using Application.Features.Magazines.Constants;
using Application.Features.Magazines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Magazines.Constants.MagazinesOperationClaims;

namespace Application.Features.Magazines.Queries.GetById;

public class GetByIdMagazineQuery : IRequest<GetByIdMagazineResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMagazineQueryHandler : IRequestHandler<GetByIdMagazineQuery, GetByIdMagazineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMagazineRepository _magazineRepository;
        private readonly MagazineBusinessRules _magazineBusinessRules;

        public GetByIdMagazineQueryHandler(IMapper mapper, IMagazineRepository magazineRepository, MagazineBusinessRules magazineBusinessRules)
        {
            _mapper = mapper;
            _magazineRepository = magazineRepository;
            _magazineBusinessRules = magazineBusinessRules;
        }

        public async Task<GetByIdMagazineResponse> Handle(GetByIdMagazineQuery request, CancellationToken cancellationToken)
        {
            Magazine? magazine = await _magazineRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _magazineBusinessRules.MagazineShouldExistWhenSelected(magazine);

            GetByIdMagazineResponse response = _mapper.Map<GetByIdMagazineResponse>(magazine);
            return response;
        }
    }
}