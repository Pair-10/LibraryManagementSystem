using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Authors.Queries.GetDynamic;
public class MaterialDto : IDto
{
    public Guid MaterialId { get; set; }
    public string MaterialName { get; set; }
}
