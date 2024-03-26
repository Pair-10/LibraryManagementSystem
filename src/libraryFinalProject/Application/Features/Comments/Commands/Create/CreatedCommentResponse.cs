using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Create;

public class CreatedCommentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentDesc { get; set; }
}