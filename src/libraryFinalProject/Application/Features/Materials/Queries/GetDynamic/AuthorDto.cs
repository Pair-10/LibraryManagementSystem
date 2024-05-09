using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Materials.Queries.GetDynamic;
public class AuthorDto : IDto
{
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string AuthorSurname { get; set; }

}
