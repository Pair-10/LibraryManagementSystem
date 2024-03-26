using NArchitecture.Core.Application.Responses;

namespace Application.Features.Baskets.Commands.Update;

public class UpdatedBasketResponse : IResponse
{
    public Guid Id { get; set; }
    public int ItemQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}