//using Application.Features.Penalties.Constants;
//using Application.Features.Penalties.Rules;
//using Application.Services.Repositories;
//using AutoMapper;
//using Domain.Entities;
//using NArchitecture.Core.Application.Pipelines.Authorization;
//using MediatR;
//using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;
//using Application.Features.Penalties.Queries.GetById;

//namespace Application.Features.Penalties.Queries.GetUserById;

//public class GetByUserIdPenaltyQuery : IRequest<GetByUserIdPenaltyResponse>, ISecuredRequest
//{
//    public Guid UserId { get; set; }

//    public string[] Roles => [Admin, Read];

//    public class GetByUserIdPenaltyQueryHandler : IRequestHandler<GetByUserIdPenaltyQuery, GetByUserIdPenaltyResponse>
//    {
//        private readonly IMapper _mapper;
//        private readonly IPenaltyRepository _penaltyRepository;
//        private readonly PenaltyBusinessRules _penaltyBusinessRules;

//        public GetByUserIdPenaltyQueryHandler(IMapper mapper, IPenaltyRepository penaltyRepository, PenaltyBusinessRules penaltyBusinessRules)
//        {
//            _mapper = mapper;
//            _penaltyRepository = penaltyRepository;
//            _penaltyBusinessRules = penaltyBusinessRules;
//        }

//        public async Task<GetByUserIdPenaltyResponse> Handle(GetByUserIdPenaltyQuery request, CancellationToken cancellationToken)
//        {
//            Penalty? penalty = await _penaltyRepository.GetAsync(predicate: p => p.UserId == request.UserId, cancellationToken: cancellationToken);
//            await _penaltyBusinessRules.PenaltyShouldExistWhenSelected(penalty);

//            GetByUserIdPenaltyResponse response = _mapper.Map<GetByUserIdPenaltyResponse>(penalty);//
//            return response;
//        }
//    }
//}

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Penalties.Queries.GetUserById
{
    public class GetAllPenaltiesQuery : IRequest<List<Penalty>>, ISecuredRequest
    {
        public string[] Roles => new string[] { "Admin", "Read" };
    }

    public class GetAllPenaltiesQueryHandler : IRequestHandler<GetAllPenaltiesQuery, List<Penalty>>
    {
        private readonly IPenaltyRepository _penaltyRepository;

        public GetAllPenaltiesQueryHandler(IPenaltyRepository penaltyRepository)
        {
            _penaltyRepository = penaltyRepository;
        }

        public async Task<List<Penalty>> Handle(GetAllPenaltiesQuery request, CancellationToken cancellationToken)
        {
            var penalties = await _penaltyRepository.GetAllAsync(cancellationToken);
            return penalties;
        }
    }
}
