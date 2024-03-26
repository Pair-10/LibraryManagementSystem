using Application.Features.Types.Constants;
using Application.Features.Types.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Types.Constants.TypesOperationClaims;

namespace Application.Features.Types.Commands.Update;

public class UpdateTypeCommand : IRequest<UpdatedTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, TypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTypes"];

    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, UpdatedTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;
        private readonly TypeBusinessRules _typeBusinessRules;

        public UpdateTypeCommandHandler(IMapper mapper, ITypeRepository typeRepository,
                                         TypeBusinessRules typeBusinessRules)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<UpdatedTypeResponse> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            Type? type = await _typeRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _typeBusinessRules.TypeShouldExistWhenSelected(type);
            type = _mapper.Map(request, type);

            await _typeRepository.UpdateAsync(type!);

            UpdatedTypeResponse response = _mapper.Map<UpdatedTypeResponse>(type);
            return response;
        }
    }
}