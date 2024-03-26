using NArchitecture.Core.Application.Responses;

namespace Application.Features.Books.Commands.Update;

public class UpdatedBookResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISBN { get; set; }
}