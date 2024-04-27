using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAuthors.Commands.Create;

public class CreatedMaterialAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }
}