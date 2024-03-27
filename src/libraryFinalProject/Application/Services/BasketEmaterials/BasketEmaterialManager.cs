using Application.Features.BasketEmaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BasketEmaterials;

public class BasketEmaterialManager : IBasketEmaterialService
{
    private readonly IBasketEmaterialRepository _basketEmaterialRepository;
    private readonly BasketEmaterialBusinessRules _basketEmaterialBusinessRules;

    public BasketEmaterialManager(IBasketEmaterialRepository basketEmaterialRepository, BasketEmaterialBusinessRules basketEmaterialBusinessRules)
    {
        _basketEmaterialRepository = basketEmaterialRepository;
        _basketEmaterialBusinessRules = basketEmaterialBusinessRules;
    }

    public async Task<BasketEmaterial?> GetAsync(
        Expression<Func<BasketEmaterial, bool>> predicate,
        Func<IQueryable<BasketEmaterial>, IIncludableQueryable<BasketEmaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BasketEmaterial? basketEmaterial = await _basketEmaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return basketEmaterial;
    }

    public async Task<IPaginate<BasketEmaterial>?> GetListAsync(
        Expression<Func<BasketEmaterial, bool>>? predicate = null,
        Func<IQueryable<BasketEmaterial>, IOrderedQueryable<BasketEmaterial>>? orderBy = null,
        Func<IQueryable<BasketEmaterial>, IIncludableQueryable<BasketEmaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BasketEmaterial> basketEmaterialList = await _basketEmaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return basketEmaterialList;
    }

    public async Task<BasketEmaterial> AddAsync(BasketEmaterial basketEmaterial)
    {
        BasketEmaterial addedBasketEmaterial = await _basketEmaterialRepository.AddAsync(basketEmaterial);

        return addedBasketEmaterial;
    }

    public async Task<BasketEmaterial> UpdateAsync(BasketEmaterial basketEmaterial)
    {
        BasketEmaterial updatedBasketEmaterial = await _basketEmaterialRepository.UpdateAsync(basketEmaterial);

        return updatedBasketEmaterial;
    }

    public async Task<BasketEmaterial> DeleteAsync(BasketEmaterial basketEmaterial, bool permanent = false)
    {
        BasketEmaterial deletedBasketEmaterial = await _basketEmaterialRepository.DeleteAsync(basketEmaterial);

        return deletedBasketEmaterial;
    }
}
