using Application.Features.PaymentTypes.Commands.Create;
using Application.Features.PaymentTypes.Commands.Delete;
using Application.Features.PaymentTypes.Commands.Update;
using Application.Features.PaymentTypes.Queries.GetById;
using Application.Features.PaymentTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PaymentTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PaymentType, CreatePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, CreatedPaymentTypeResponse>().ReverseMap();
        CreateMap<PaymentType, UpdatePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, UpdatedPaymentTypeResponse>().ReverseMap();
        CreateMap<PaymentType, DeletePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, DeletedPaymentTypeResponse>().ReverseMap();
        CreateMap<PaymentType, GetByIdPaymentTypeResponse>().ReverseMap();
        CreateMap<PaymentType, GetListPaymentTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<PaymentType>, GetListResponse<GetListPaymentTypeListItemDto>>().ReverseMap();
    }
}