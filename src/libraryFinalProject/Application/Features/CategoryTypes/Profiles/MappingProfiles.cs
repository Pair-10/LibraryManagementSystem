using Application.Features.CategoryTypes.Commands.Create;
using Application.Features.CategoryTypes.Commands.Delete;
using Application.Features.CategoryTypes.Commands.Update;
using Application.Features.CategoryTypes.Queries.GetById;
using Application.Features.CategoryTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CategoryTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryType, CreateCategoryTypeCommand>().ReverseMap();
        CreateMap<CategoryType, CreatedCategoryTypeResponse>().ReverseMap();
        CreateMap<CategoryType, UpdateCategoryTypeCommand>().ReverseMap();
        CreateMap<CategoryType, UpdatedCategoryTypeResponse>().ReverseMap();
        CreateMap<CategoryType, DeleteCategoryTypeCommand>().ReverseMap();
        CreateMap<CategoryType, DeletedCategoryTypeResponse>().ReverseMap();
        CreateMap<CategoryType, GetByIdCategoryTypeResponse>().ReverseMap();
        CreateMap<CategoryType, GetListCategoryTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryType>, GetListResponse<GetListCategoryTypeListItemDto>>().ReverseMap();
    }
}