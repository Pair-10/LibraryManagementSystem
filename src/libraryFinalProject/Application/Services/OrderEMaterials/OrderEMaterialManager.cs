using Application.Features.OrderEMaterials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderEMaterials;

public class OrderEMaterialManager : IOrderEMaterialService
{
    private readonly IOrderEMaterialRepository _orderEMaterialRepository;
    private readonly OrderEMaterialBusinessRules _orderEMaterialBusinessRules;

    public OrderEMaterialManager(IOrderEMaterialRepository orderEMaterialRepository, OrderEMaterialBusinessRules orderEMaterialBusinessRules)
    {
        _orderEMaterialRepository = orderEMaterialRepository;
        _orderEMaterialBusinessRules = orderEMaterialBusinessRules;
    }

    public async Task<OrderEMaterial?> GetAsync(
        Expression<Func<OrderEMaterial, bool>> predicate,
        Func<IQueryable<OrderEMaterial>, IIncludableQueryable<OrderEMaterial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderEMaterial? orderEMaterial = await _orderEMaterialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderEMaterial;
    }

    public async Task<IPaginate<OrderEMaterial>?> GetListAsync(
        Expression<Func<OrderEMaterial, bool>>? predicate = null,
        Func<IQueryable<OrderEMaterial>, IOrderedQueryable<OrderEMaterial>>? orderBy = null,
        Func<IQueryable<OrderEMaterial>, IIncludableQueryable<OrderEMaterial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderEMaterial> orderEMaterialList = await _orderEMaterialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderEMaterialList;
    }

    public async Task<OrderEMaterial> AddAsync(OrderEMaterial orderEMaterial)
    {
        OrderEMaterial addedOrderEMaterial = await _orderEMaterialRepository.AddAsync(orderEMaterial);

        return addedOrderEMaterial;
    }

    public async Task<OrderEMaterial> UpdateAsync(OrderEMaterial orderEMaterial)
    {
        OrderEMaterial updatedOrderEMaterial = await _orderEMaterialRepository.UpdateAsync(orderEMaterial);

        return updatedOrderEMaterial;
    }

    public async Task<OrderEMaterial> DeleteAsync(OrderEMaterial orderEMaterial, bool permanent = false)
    {
        OrderEMaterial deletedOrderEMaterial = await _orderEMaterialRepository.DeleteAsync(orderEMaterial);

        return deletedOrderEMaterial;
    }
}
