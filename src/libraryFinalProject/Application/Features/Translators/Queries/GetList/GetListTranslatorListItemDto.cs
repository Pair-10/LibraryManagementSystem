using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Translators.Queries.GetList;

public class GetListTranslatorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Bio { get; set; }
    public string Website { get; set; }
}