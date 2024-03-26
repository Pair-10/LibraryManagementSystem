using Application.Features.MaterialAuthors.Commands.Create;
using Application.Features.MaterialAuthors.Commands.Delete;
using Application.Features.MaterialAuthors.Commands.Update;
using Application.Features.MaterialAuthors.Queries.GetById;
using Application.Features.MaterialAuthors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialAuthors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialAuthor, CreateMaterialAuthorCommand>().ReverseMap();
        CreateMap<MaterialAuthor, CreatedMaterialAuthorResponse>().ReverseMap();
        CreateMap<MaterialAuthor, UpdateMaterialAuthorCommand>().ReverseMap();
        CreateMap<MaterialAuthor, UpdatedMaterialAuthorResponse>().ReverseMap();
        CreateMap<MaterialAuthor, DeleteMaterialAuthorCommand>().ReverseMap();
        CreateMap<MaterialAuthor, DeletedMaterialAuthorResponse>().ReverseMap();
        CreateMap<MaterialAuthor, GetByIdMaterialAuthorResponse>().ReverseMap();
        CreateMap<MaterialAuthor, GetListMaterialAuthorListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialAuthor>, GetListResponse<GetListMaterialAuthorListItemDto>>().ReverseMap();
    }
}