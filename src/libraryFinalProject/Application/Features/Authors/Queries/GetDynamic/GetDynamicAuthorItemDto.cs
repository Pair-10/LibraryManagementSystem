using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Authors.Queries.GetDynamic;
public class GetDynamicAuthorItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<MaterialDto> Materials { get; set; }

}
