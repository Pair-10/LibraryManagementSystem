using Application.Features.Books.Constants;
using Application.Features.Books.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Books.Constants.BooksOperationClaims;

namespace Application.Features.Books.Commands.Update;

public class UpdateBookCommand : IRequest<UpdatedBookResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ISBN { get; set; }

    public string[] Roles => [Admin, Write, BooksOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBooks"];

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdatedBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly BookBusinessRules _bookBusinessRules;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository,
                                         BookBusinessRules bookBusinessRules)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookBusinessRules = bookBusinessRules;
        }

        public async Task<UpdatedBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _bookBusinessRules.BookShouldNotExistsWithSameISBN(request.ISBN);//ISBN deðer kontrolü
            Book? book = await _bookRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookBusinessRules.BookShouldExistWhenSelected(book);
            book = _mapper.Map(request, book);

            await _bookRepository.UpdateAsync(book!);

            UpdatedBookResponse response = _mapper.Map<UpdatedBookResponse>(book);
            return response;
        }
    }
}