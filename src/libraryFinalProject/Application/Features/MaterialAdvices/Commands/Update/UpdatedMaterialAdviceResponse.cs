using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAdvices.Commands.Update;

public class UpdatedMaterialAdviceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public bool Status { get; set; }
    public string MaterialName { get; set; }
}