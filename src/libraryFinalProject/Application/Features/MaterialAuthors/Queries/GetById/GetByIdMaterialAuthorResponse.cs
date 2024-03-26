using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAuthors.Queries.GetById;

public class GetByIdMaterialAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid AuthorId { get; set; }
}