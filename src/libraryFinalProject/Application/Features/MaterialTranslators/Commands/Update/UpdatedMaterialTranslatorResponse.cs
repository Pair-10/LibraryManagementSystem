using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTranslators.Commands.Update;

public class UpdatedMaterialTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}