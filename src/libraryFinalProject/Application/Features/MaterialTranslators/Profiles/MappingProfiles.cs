using Application.Features.MaterialTranslators.Commands.Create;
using Application.Features.MaterialTranslators.Commands.Delete;
using Application.Features.MaterialTranslators.Commands.Update;
using Application.Features.MaterialTranslators.Queries.GetById;
using Application.Features.MaterialTranslators.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialTranslators.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialTranslator, CreateMaterialTranslatorCommand>().ReverseMap();
        CreateMap<MaterialTranslator, CreatedMaterialTranslatorResponse>().ReverseMap();
        CreateMap<MaterialTranslator, UpdateMaterialTranslatorCommand>().ReverseMap();
        CreateMap<MaterialTranslator, UpdatedMaterialTranslatorResponse>().ReverseMap();
        CreateMap<MaterialTranslator, DeleteMaterialTranslatorCommand>().ReverseMap();
        CreateMap<MaterialTranslator, DeletedMaterialTranslatorResponse>().ReverseMap();
        CreateMap<MaterialTranslator, GetByIdMaterialTranslatorResponse>().ReverseMap();
        CreateMap<MaterialTranslator, GetListMaterialTranslatorListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialTranslator>, GetListResponse<GetListMaterialTranslatorListItemDto>>().ReverseMap();
    }
}