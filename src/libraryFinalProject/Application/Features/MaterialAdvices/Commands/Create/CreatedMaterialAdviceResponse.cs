using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAdvices.Commands.Create;

public class CreatedMaterialAdviceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public string Status { get; set; }
    public string MaterialName { get; set; }
}