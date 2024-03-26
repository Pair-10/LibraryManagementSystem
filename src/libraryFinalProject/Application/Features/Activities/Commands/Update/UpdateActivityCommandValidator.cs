using FluentValidation;

namespace Application.Features.Activities.Commands.Update;

public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ActivityDate).NotEmpty();
        RuleFor(c => c.Desc).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.ActivityName).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
    }
}