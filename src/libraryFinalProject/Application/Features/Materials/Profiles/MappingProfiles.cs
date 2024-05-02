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

        CreateMap<GetDynamicMaterialItemDto, Material>().ReverseMap().ForMember(i => i.AuthorName, opt => opt.MapFrom(j => j.MaterialAuthors));
        CreateMap<GetDynamicMaterialItemDto, MaterialAuthor>().ReverseMap().ForMember(i => i.AuthorName, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));

        CreateMap<GetDynamicMaterialItemDto, Material>().ReverseMap().ForMember(i => i.CategoryName, opt => opt.MapFrom(j => j.CategoryTypes));
        CreateMap<GetDynamicMaterialItemDto, CategoryType>().ReverseMap().ForMember(i => i.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<GetDynamicMaterialItemDto, Material>().ReverseMap().ForMember(i => i.TranslatorName, opt => opt.MapFrom(j => j.MaterialTranslators));
        CreateMap<GetDynamicMaterialItemDto, MaterialTranslator>().ReverseMap().ForMember(i => i.TranslatorName, opt => opt.MapFrom(src => src.Translator.Name + " " + src.Translator.Surname));

        CreateMap<GetDynamicMaterialItemDto, Material>().ReverseMap().ForMember(i => i.PublisherName, opt => opt.MapFrom(j => j.MaterialPublishers));
        CreateMap<GetDynamicMaterialItemDto, MaterialPublisher>().ReverseMap().ForMember(i => i.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));

    }


}