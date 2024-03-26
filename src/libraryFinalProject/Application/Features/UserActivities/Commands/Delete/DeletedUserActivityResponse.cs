using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserActivities.Commands.Delete;

public class DeletedUserActivityResponse : IResponse
{
    public Guid Id { get; set; }
}