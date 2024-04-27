using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BasketEmaterials.Queries.GetList;

public class GetListBasketEmaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid EmaterialId { get; set; }
    public Guid BasketId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}