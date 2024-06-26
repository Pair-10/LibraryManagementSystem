using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Queries.GetById;

public class GetByIdMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}