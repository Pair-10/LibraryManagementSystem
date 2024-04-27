using NArchitecture.Core.Application.Responses;

namespace Application.Features.Magazines.Commands.Delete;

public class DeletedMagazineResponse : IResponse
{
    public Guid Id { get; set; }
}