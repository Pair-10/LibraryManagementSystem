using Application.Features.Comments.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    private ILocalizationService _localizationService;
    public UpdateCommentCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CommentDate).NotEmpty();
        RuleFor(c => c.CommentDesc).NotEmpty().MinimumLength(2).MaximumLength(200).WithMessage(GetLocalized("DescMustBeLength").Result);
        _localizationService = localizationService;
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, CommentsBusinessMessages.SectionName);

    }
}