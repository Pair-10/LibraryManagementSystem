using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTranslators.Commands.Delete;

public class DeletedMaterialTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
}