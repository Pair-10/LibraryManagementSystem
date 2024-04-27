using NArchitecture.Core.Application.Responses;

namespace Application.Features.CategoryTypes.Queries.GetById;

public class GetByIdCategoryTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid MaterialTypeId { get; set; }
}