using Application.Features.MaterialPublishers.Commands.Create;
using Application.Features.MaterialPublishers.Commands.Delete;
using Application.Features.MaterialPublishers.Commands.Update;
using Application.Features.MaterialPublishers.Queries.GetById;
using Application.Features.MaterialPublishers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaterialPublishers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaterialPublisher, CreateMaterialPublisherCommand>().ReverseMap();
        CreateMap<MaterialPublisher, CreatedMaterialPublisherResponse>().ReverseMap();
        CreateMap<MaterialPublisher, UpdateMaterialPublisherCommand>().ReverseMap();
        CreateMap<MaterialPublisher, UpdatedMaterialPublisherResponse>().ReverseMap();
        CreateMap<MaterialPublisher, DeleteMaterialPublisherCommand>().ReverseMap();
        CreateMap<MaterialPublisher, DeletedMaterialPublisherResponse>().ReverseMap();
        CreateMap<MaterialPublisher, GetByIdMaterialPublisherResponse>().ReverseMap();
        CreateMap<MaterialPublisher, GetListMaterialPublisherListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaterialPublisher>, GetListResponse<GetListMaterialPublisherListItemDto>>().ReverseMap();
    }
}