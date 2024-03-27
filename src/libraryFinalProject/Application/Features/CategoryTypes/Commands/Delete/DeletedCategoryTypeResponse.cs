using NArchitecture.Core.Application.Responses;

namespace Application.Features.CategoryTypes.Commands.Delete;

public class DeletedCategoryTypeResponse : IResponse
{
    public Guid Id { get; set; }
}