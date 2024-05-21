using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetDynamic;
using Application.Features.Materials.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Materials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Material, CreateMaterialCommand>().ReverseMap();
        CreateMap<Material, CreatedMaterialResponse>().ReverseMap();
        CreateMap<Material, UpdateMaterialCommand>().ReverseMap();
        CreateMap<Material, UpdatedMaterialResponse>().ReverseMap();
        CreateMap<Material, DeleteMaterialCommand>().ReverseMap();
        CreateMap<Material, DeletedMaterialResponse>().ReverseMap();
        CreateMap<Material, GetByIdMaterialResponse>().ReverseMap();
        CreateMap<Material, GetListMaterialListItemDto>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetListMaterialListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetDynamicMaterialItemDto>>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetDynamicMaterialAuthorDto>>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetDynamicMaterialCategoryDto>>().ReverseMap();
        CreateMap<IPaginate<Material>, GetListResponse<GetDynamicMaterialPublisherDto>>().ReverseMap();

        CreateMap<MaterialAuthor, GetDynamicMaterialAuthorDto>().ReverseMap();
        CreateMap<MaterialPublisher, GetDynamicMaterialPublisherDto>().ReverseMap();
        CreateMap<CategoryType, GetDynamicMaterialCategoryDto>().ReverseMap();
        CreateMap<MaterialAuthor, Author>().ReverseMap();
        CreateMap<MaterialPublisher, Publisher>().ReverseMap();
        CreateMap<CategoryType, Category>().ReverseMap();

        CreateMap<GetDynamicMaterialItemDto, Material>().ReverseMap()
            .ForMember(i => i.Publishers, opt => opt.MapFrom(j => j.MaterialPublishers))
            .ForMember(i => i.Authors, opt => opt.MapFrom(j => j.MaterialAuthors))
            .ForMember(i => i.Categories, opt => opt.MapFrom(j => j.CategoryTypes));

        CreateMap<GetDynamicMaterialItemDto, GetDynamicMaterialPublisherDto>().ReverseMap();
        CreateMap<GetDynamicMaterialItemDto, GetDynamicMaterialAuthorDto>().ReverseMap();
        CreateMap<GetDynamicMaterialAuthorDto, Author>().ReverseMap()
            .ForMember(i => i.AuthorName, opt => opt.MapFrom(j => j.Name))
            .ForMember(i => i.AuthorSurname, opt => opt.MapFrom(j => j.Surname))
            .ForMember(i => i.AuthorId, opt => opt.MapFrom(j => j.Id));

        CreateMap<GetDynamicMaterialPublisherDto, Publisher>().ReverseMap()
            .ForMember(i => i.PublisherName, opt => opt.MapFrom(j => j.Name))
            .ForMember(i => i.PublisherId, opt => opt.MapFrom(j => j.Id));

        CreateMap<GetDynamicMaterialCategoryDto, Category>().ReverseMap()
            .ForMember(i => i.CategoryId, opt => opt.MapFrom(j => j.Id))
            .ForMember(i => i.CategoryName, opt => opt.MapFrom(j => j.Name));
    }
}