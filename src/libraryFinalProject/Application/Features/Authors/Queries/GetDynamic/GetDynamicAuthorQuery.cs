using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Authors.Queries.GetDynamic;
public class GetDynamicAuthorQuery : IRequest<GetListResponse<GetDynamicAuthorItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

    public class GetDynamicAuthorQueryHandler : IRequestHandler<GetDynamicAuthorQuery, GetListResponse<GetDynamicAuthorItemDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetDynamicAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicAuthorItemDto>> Handle(GetDynamicAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, include: i => i.Include(i => i.MaterialAuthors).ThenInclude(i => i.Material));

            GetListResponse<GetDynamicAuthorItemDto> response = _mapper.Map<GetListResponse<GetDynamicAuthorItemDto>>(authors);

            return response;
        }
    }
}
