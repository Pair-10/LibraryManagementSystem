using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ematerials.Queries.GetById;

public class GetByIdEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryTypeId { get; set; }
    public decimal Price { get; set; }
    public string PdfUrl { get; set; }
}