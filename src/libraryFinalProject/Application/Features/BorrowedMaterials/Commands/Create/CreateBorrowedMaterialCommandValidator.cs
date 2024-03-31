using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Create;

public class CreateBorrowedMaterialCommandValidator : AbstractValidator<CreateBorrowedMaterialCommand>
{
    public CreateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Deadline).Must(BeValidDeadlineDate).WithMessage("Invalid Deadline Date.").NotEmpty();//ge�mi� tarih kontrol�
    }
    private bool BeValidDeadlineDate(DateTime date)//kontrol edilecek son teslim tarihi
    {
        return date >= DateTime.Today;//bugunden buyuk beya e�itse tarih true d�nd�r
    }
}