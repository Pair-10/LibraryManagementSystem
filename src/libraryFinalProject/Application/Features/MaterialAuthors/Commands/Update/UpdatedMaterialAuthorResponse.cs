using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAuthors.Commands.Update;

public class UpdatedMaterialAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }
}