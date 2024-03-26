using FluentValidation;

namespace Application.Features.UserAddresses.Commands.Delete;

public class DeleteUserAddressCommandValidator : AbstractValidator<DeleteUserAddressCommand>
{
    public DeleteUserAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}