using FluentValidation;

namespace Application.Features.Reservations.Commands.Update;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.ReservationDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}