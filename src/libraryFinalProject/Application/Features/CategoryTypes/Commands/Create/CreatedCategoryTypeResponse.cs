using NArchitecture.Core.Application.Responses;

namespace Application.Features.CategoryTypes.Commands.Create;

public class CreatedCategoryTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid MaterialTypeId { get; set; }
}