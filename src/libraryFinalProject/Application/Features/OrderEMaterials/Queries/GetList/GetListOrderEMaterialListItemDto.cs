using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderEMaterials.Queries.GetList;

public class GetListOrderEMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid EMaterialId { get; set; }
    public Guid OrderId { get; set; }
    public decimal QuantityPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}