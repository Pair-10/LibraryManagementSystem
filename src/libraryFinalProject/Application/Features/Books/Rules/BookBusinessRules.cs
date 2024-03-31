using Application.Features.Books.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Activities.Constants;
using Application.Features.Articles.Constants;

namespace Application.Features.Books.Rules;

public class BookBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;//
    private readonly IBookRepository _bookRepository;
    private readonly ILocalizationService _localizationService;

    public BookBusinessRules(IBookRepository bookRepository, ILocalizationService localizationService, ICategoryRepository categoryRepository)
    {
        _bookRepository = bookRepository;
        _localizationService = localizationService;
        _categoryRepository = categoryRepository;//ctor categoryrepo eklendi   
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BooksBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BookShouldExistWhenSelected(Book? book)
    {
        if (book == null)
            await throwBusinessException(BooksBusinessMessages.BookNotExists);
    }

    public async Task BookIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Book? book = await _bookRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookShouldExistWhenSelected(book);
    }
    public async Task BookShouldNotExistsWithSameISBN(string isbn)//
    {
        Book? bookWithSameName = await _bookRepository.GetAsync(b => b.ISBN == isbn);//

        if (bookWithSameName is not null)//
            throw new BusinessException(BooksBusinessMessages.IsbnAlreadyExist);//message kodunu al 
    }
    //
    public async Task CategoryShouldExist(Guid categoryId)
    {
        // Bu kategoriye �zg� bir GUID belirle 
        Guid specificCategoryId = new Guid("1405d907-289c-43a0-9bca-08dc51d1dbe5");//son halinde sabit kalacak 

        // Veritaban�nda belirtilen Category ID de�erine sahip kategori ve istedi�im guid e�it mi kontrol et
        var category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == categoryId && c.Id == specificCategoryId,
            enableTracking: false
        );

        // E�er kategori bulunamazsa hata mesaj�n� olu�tur ev bir istisna f�rlat
        if (category == null)
        {
            await throwBusinessException(BooksBusinessMessages.CategoryNotExists);
        }
    }
}