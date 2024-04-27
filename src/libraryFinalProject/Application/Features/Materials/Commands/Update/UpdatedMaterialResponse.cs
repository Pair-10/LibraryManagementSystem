using NArchitecture.Core.Application.Responses;

namespace Application.Features.Materials.Commands.Update;

public class UpdatedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Language { get; set; }
    public int PageCount { get; set; }
    public bool Status { get; set; }
    public string MaterialName { get; set; }
    public int Quantity { get; set; }
}