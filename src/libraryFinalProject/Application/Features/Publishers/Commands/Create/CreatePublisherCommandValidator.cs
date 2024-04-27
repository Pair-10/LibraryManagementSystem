using FluentValidation;

namespace Application.Features.Publishers.Commands.Create;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.WebSite).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
                                                           //Telefon numarasý gereklidir.
        RuleFor(c => c.AddressId).NotEmpty();
    }
}
