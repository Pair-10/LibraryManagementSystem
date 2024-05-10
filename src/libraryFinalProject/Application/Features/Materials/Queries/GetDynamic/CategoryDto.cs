using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetDynamic;
public class CategoryDto : IDto
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}
