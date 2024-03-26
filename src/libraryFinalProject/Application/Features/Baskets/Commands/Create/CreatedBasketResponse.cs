using NArchitecture.Core.Application.Responses;

namespace Application.Features.Baskets.Commands.Create;

public class CreatedBasketResponse : IResponse
{
    public Guid Id { get; set; }
    public int ItemQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}