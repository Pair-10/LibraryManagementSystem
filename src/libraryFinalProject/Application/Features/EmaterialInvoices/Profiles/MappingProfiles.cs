using Application.Features.EmaterialInvoices.Commands.Create;
using Application.Features.EmaterialInvoices.Commands.Delete;
using Application.Features.EmaterialInvoices.Commands.Update;
using Application.Features.EmaterialInvoices.Queries.GetById;
using Application.Features.EmaterialInvoices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.EmaterialInvoices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EmaterialInvoice, CreateEmaterialInvoiceCommand>().ReverseMap();
        CreateMap<EmaterialInvoice, CreatedEmaterialInvoiceResponse>().ReverseMap();
        CreateMap<EmaterialInvoice, UpdateEmaterialInvoiceCommand>().ReverseMap();
        CreateMap<EmaterialInvoice, UpdatedEmaterialInvoiceResponse>().ReverseMap();
        CreateMap<EmaterialInvoice, DeleteEmaterialInvoiceCommand>().ReverseMap();
        CreateMap<EmaterialInvoice, DeletedEmaterialInvoiceResponse>().ReverseMap();
        CreateMap<EmaterialInvoice, GetByIdEmaterialInvoiceResponse>().ReverseMap();
        CreateMap<EmaterialInvoice, GetListEmaterialInvoiceListItemDto>().ReverseMap();
        CreateMap<IPaginate<EmaterialInvoice>, GetListResponse<GetListEmaterialInvoiceListItemDto>>().ReverseMap();
    }
}