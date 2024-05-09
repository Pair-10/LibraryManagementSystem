using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Materials.Queries.GetDynamic;
public class GetDynamicMaterialQuery : IRequest<GetListResponse<GetDynamicMaterialItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }


    public class GetDynamicMaterialQueryHandler : IRequestHandler<GetDynamicMaterialQuery, GetListResponse<GetDynamicMaterialItemDto>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetDynamicMaterialQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicMaterialItemDto>> Handle(GetDynamicMaterialQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, include: i => i.Include(i => i.MaterialPublishers).ThenInclude(m => m.Publisher).Include(i => i.MaterialAuthors).ThenInclude(a => a.Author).Include(i => i.CategoryTypes).ThenInclude(c => c.Category));

            GetListResponse<GetDynamicMaterialItemDto> response = _mapper.Map<GetListResponse<GetDynamicMaterialItemDto>>(materials);

            return response;
        }
    }
}
