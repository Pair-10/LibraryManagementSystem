using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PaymentTypes.Queries.GetList;

public class GetListPaymentTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}