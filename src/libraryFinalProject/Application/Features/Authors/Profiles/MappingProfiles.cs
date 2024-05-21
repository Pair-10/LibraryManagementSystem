using Application.Features.Authors.Commands.Create;
using Application.Features.Authors.Commands.Delete;
using Application.Features.Authors.Commands.Update;
using Application.Features.Authors.Queries.GetById;
using Application.Features.Authors.Queries.GetDynamic;
using Application.Features.Authors.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Authors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Author, CreateAuthorCommand>().ReverseMap();
        CreateMap<Author, CreatedAuthorResponse>().ReverseMap();
        CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
        CreateMap<Author, UpdatedAuthorResponse>().ReverseMap();
        CreateMap<Author, DeleteAuthorCommand>().ReverseMap();
        CreateMap<Author, DeletedAuthorResponse>().ReverseMap();
        CreateMap<Author, GetByIdAuthorResponse>().ReverseMap();
        CreateMap<Author, GetListAuthorListItemDto>().ReverseMap();
        CreateMap<MaterialAuthor, Material>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetListAuthorListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetDynamicAuthorItemDto>>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetDynamicAuthorMaterialDto>>().ReverseMap();
        CreateMap<GetDynamicAuthorItemDto, Author>().ReverseMap()
             .ForMember(i => i.Materials, opt => opt.MapFrom(j => j.MaterialAuthors));


        CreateMap<GetDynamicAuthorItemDto, GetDynamicAuthorMaterialDto>().ReverseMap();
        CreateMap<MaterialAuthor, GetDynamicAuthorMaterialDto>().ReverseMap();


        CreateMap<GetDynamicAuthorMaterialDto, Material>().ReverseMap()
            .ForMember(i => i.MaterialId, opt => opt.MapFrom(j => j.Id))
            .ForMember(i => i.MaterialName, opt => opt.MapFrom(j => j.MaterialName));


    }
}