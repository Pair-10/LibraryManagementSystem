using FluentValidation;

namespace Application.Features.BorrowedMaterials.Commands.Update;

public class UpdateBorrowedMaterialCommandValidator : AbstractValidator<UpdateBorrowedMaterialCommand>
{
    public UpdateBorrowedMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Deadline).Must(BeValidDeadlineDate).WithMessage("Invalid Deadline Date.").NotEmpty();//geçmiþ tarih kontrolü
    }
    private bool BeValidDeadlineDate(DateTime date)//kontrol edilecek son teslim tarihi
    {//
        return date >= DateTime.Today;//bugunden buyuk beya eþitse tarih true döndür
    }//
}