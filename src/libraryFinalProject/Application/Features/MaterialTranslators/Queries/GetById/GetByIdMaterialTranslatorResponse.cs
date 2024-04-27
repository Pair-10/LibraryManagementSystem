using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTranslators.Queries.GetById;

public class GetByIdMaterialTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}