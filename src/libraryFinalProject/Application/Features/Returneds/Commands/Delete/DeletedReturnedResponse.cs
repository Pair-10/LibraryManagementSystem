using NArchitecture.Core.Application.Responses;

namespace Application.Features.Returneds.Commands.Delete;

public class DeletedReturnedResponse : IResponse
{
    public Guid Id { get; set; }
}