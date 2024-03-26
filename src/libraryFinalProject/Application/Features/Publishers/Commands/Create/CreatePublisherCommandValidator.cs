using FluentValidation;

namespace Application.Features.Publishers.Commands.Create;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.WebSite).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
    }
}