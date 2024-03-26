using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialAdvices.Commands.Delete;

public class DeletedMaterialAdviceResponse : IResponse
{
    public Guid Id { get; set; }
}