using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaterialTranslators.Queries.GetList;

public class GetListMaterialTranslatorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}