using NArchitecture.Core.Application.Responses;

namespace Application.Features.CategoryTypes.Commands.Update;

public class UpdatedCategoryTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TypeId { get; set; }
}