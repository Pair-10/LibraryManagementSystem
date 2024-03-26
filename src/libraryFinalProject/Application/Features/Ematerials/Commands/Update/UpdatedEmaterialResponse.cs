using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ematerials.Commands.Update;

public class UpdatedEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryTypeId { get; set; }
    public decimal Price { get; set; }
    public string PdfUrl { get; set; }
}