using Application.Features.MaterialAdvices.Commands.Create;
using Application.Features.MaterialAdvices.Commands.Delete;
using Application.Features.MaterialAdvices.Commands.Update;
using Application.Features.MaterialAdvices.Queries.GetById;
using Application.Features.MaterialAdvices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialAdvices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialAdvice, CreateMaterialAdviceCommand>().ReverseMap();
        CreateMap<MaterialAdvice, CreatedMaterialAdviceResponse>().ReverseMap();
        CreateMap<MaterialAdvice, UpdateMaterialAdviceCommand>().ReverseMap();
        CreateMap<MaterialAdvice, UpdatedMaterialAdviceResponse>().ReverseMap();
        CreateMap<MaterialAdvice, DeleteMaterialAdviceCommand>().ReverseMap();
        CreateMap<MaterialAdvice, DeletedMaterialAdviceResponse>().ReverseMap();
        CreateMap<MaterialAdvice, GetByIdMaterialAdviceResponse>().ReverseMap();
        CreateMap<MaterialAdvice, GetListMaterialAdviceListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialAdvice>, GetListResponse<GetListMaterialAdviceListItemDto>>().ReverseMap();
    }
}