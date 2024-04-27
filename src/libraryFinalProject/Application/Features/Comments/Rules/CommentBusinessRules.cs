using Application.Features.Comments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Comments.Rules;

public class CommentBusinessRules : BaseBusinessRules
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ILocalizationService _localizationService;

    public CommentBusinessRules(ICommentRepository commentRepository, ILocalizationService localizationService, IUserRepository userRepository, IMaterialRepository materialRepository)
    {
        _commentRepository = commentRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _materialRepository = materialRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CommentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CommentShouldExistWhenSelected(Comment? comment)
    {
        if (comment == null)
            await throwBusinessException(CommentsBusinessMessages.CommentNotExists);
    }

    public async Task CommentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Comment? comment = await _commentRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CommentShouldExistWhenSelected(comment);
    }

    public async Task UserIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(
            predicate: u => u.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (user == null)
            await throwBusinessException(CommentsBusinessMessages.UserNotFound);
    }

    public async Task MaterialIdShouldExist(Guid id, CancellationToken cancellationToken)
    {
        Material? material = await _materialRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (material == null)
            await throwBusinessException(CommentsBusinessMessages.MaterialNotFound);
    }
}
//Yorum id si benzersiz olmalý. - Ýþ kuralý.
//Yorum yapýlacak olan materyalin ve kullanýcýnýn mevcut olmasý gerekiyor. - Ýþ kuralý.
//Yapýlan yorumun belli bir karakter sýnýrý olmalý. - Validasyon.