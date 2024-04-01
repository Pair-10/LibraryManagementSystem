using FluentValidation;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(4);
        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .Matches(@"^(?\d{3})?-? \d{3}-?-?\d{4}$")
            .WithMessage("Geçersiz telefon numarası formatı.");
    }
}
