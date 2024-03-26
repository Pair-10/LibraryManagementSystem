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

namespace Application.Features.Types.Commands.Create;

public class CreateTypeCommand : IRequest<CreatedTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, TypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTypes"];

    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, CreatedTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;
        private readonly TypeBusinessRules _typeBusinessRules;

        public CreateTypeCommandHandler(IMapper mapper, ITypeRepository typeRepository,
                                         TypeBusinessRules typeBusinessRules)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
            _typeBusinessRules = typeBusinessRules;
        }

        public async Task<CreatedTypeResponse> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            Type type = _mapper.Map<Type>(request);

            await _typeRepository.AddAsync(type);

            CreatedTypeResponse response = _mapper.Map<CreatedTypeResponse>(type);
            return response;
        }
    }
}