using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Ematerials.Queries.GetList;

public class GetListEmaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryTypeId { get; set; }
    public decimal Price { get; set; }
    public string PdfUrl { get; set; }
}