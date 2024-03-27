using NArchitecture.Core.Application.Responses;

namespace Application.Features.BasketEmaterials.Commands.Create;

public class CreatedBasketEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EmeterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}