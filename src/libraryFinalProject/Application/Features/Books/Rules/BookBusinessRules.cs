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
    public async Task BookShouldNotExistsWithSameISBN(string isbn)
    {
        Book? bookWithSameName = await _bookRepository.GetAsync(b => b.ISBN == isbn);

        if (bookWithSameName is not null)
            throw new BusinessException(BooksBusinessMessages.IsbnAlreadyExist);//message kodunu al 
    }
    //
    public async Task CategoryShouldExist(Guid categoryId)
    {
        // Bu kategoriye özgü bir GUID belirle 
        //Guid specificCategoryId = new Guid("7919831f-8a96-49d3-7140-08dc52576512");//son halinde sabit kalacak 

        // Veritabanýnda belirtilen Category ID deðerine sahip kategori ve istediðim guid eþit mi kontrol et
        var category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == categoryId && c.Id == categoryId,
            enableTracking: false
        );

        // Eðer kategori bulunamazsa hata mesajýný oluþtur ev bir istisna fýrlat
        if (category == null)
        {
            await throwBusinessException(BooksBusinessMessages.CategoryNotExists);
        }
    }
}