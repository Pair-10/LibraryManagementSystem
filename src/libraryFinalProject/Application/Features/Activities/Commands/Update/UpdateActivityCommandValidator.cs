using FluentValidation;

namespace Application.Features.Activities.Commands.Update;

public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ActivityDate).Must(BeValidActivityDate).WithMessage("Invalid Activity Date.").NotEmpty();//ge�mi� tarih kontrol�
        RuleFor(c => c.Desc).MaximumLength(250).WithMessage("Desc cannot exceed 250 characters.").NotEmpty();//A��klama alan� max karakter say�s� belirt
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.ActivityName).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
    }
    private bool BeValidActivityDate(DateTime date)//kontrol edilecek entkinlik tarihi
    {//
        return date >= DateTime.Today;//bugunden buyuk beya e�itse tarih true d�nd�r
    }//
}