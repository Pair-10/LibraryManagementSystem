using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderEMaterials.Queries.GetById;

public class GetByIdOrderEMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EMaterialId { get; set; }
    public Guid OrderId { get; set; }
    public decimal QuantityPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}