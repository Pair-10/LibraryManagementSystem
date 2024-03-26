using NArchitecture.Core.Application.Responses;

namespace Application.Features.Types.Queries.GetById;

public class GetByIdTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}