using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Payments.Queries.GetList;

public class GetListPaymentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public Guid PaymentTypeId { get; set; }
    public decimal PaymentPrice { get; set; }
    public string Desc { get; set; }
}