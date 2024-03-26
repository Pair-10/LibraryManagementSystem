using FluentValidation;

namespace Application.Features.UserActivities.Commands.Delete;

public class DeleteUserActivityCommandValidator : AbstractValidator<DeleteUserActivityCommand>
{
    public DeleteUserActivityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}