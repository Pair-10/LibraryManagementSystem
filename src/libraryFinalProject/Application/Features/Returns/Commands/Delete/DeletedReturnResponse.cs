using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returns.Commands.Delete;

public class DeletedReturnResponse : IResponse
{
    public Guid Id { get; set; }
}