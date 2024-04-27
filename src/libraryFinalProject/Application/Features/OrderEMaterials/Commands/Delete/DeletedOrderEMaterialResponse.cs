using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderEMaterials.Commands.Delete;

public class DeletedOrderEMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}