using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTranslators.Commands.Create;

public class CreatedMaterialTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}