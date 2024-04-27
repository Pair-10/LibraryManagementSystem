using NArchitecture.Core.Application.Responses;

namespace Application.Features.BasketEmaterials.Queries.GetById;

public class GetByIdBasketEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}