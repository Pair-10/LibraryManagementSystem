using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAuthors.Commands.Delete;

public class DeletedMaterialAuthorResponse : IResponse
{
    public Guid Id { get; set; }
}