using NArchitecture.Core.Application.Responses;

namespace Application.Features.Baskets.Queries.GetById;

public class GetByIdBasketResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int ItemQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}