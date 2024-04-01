using NArchitecture.Core.Application.Responses;

namespace Application.Features.BasketEmaterials.Commands.Update;

public class UpdatedBasketEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}