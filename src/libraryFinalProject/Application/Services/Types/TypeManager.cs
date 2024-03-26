using Application.Features.Types.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Types;

public class TypeManager : ITypeService
{
    private readonly ITypeRepository _typeRepository;
    private readonly TypeBusinessRules _typeBusinessRules;

    public TypeManager(ITypeRepository typeRepository, TypeBusinessRules typeBusinessRules)
    {
        _typeRepository = typeRepository;
        _typeBusinessRules = typeBusinessRules;
    }

    public async Task<Type?> GetAsync(
        Expression<Func<Type, bool>> predicate,
        Func<IQueryable<Type>, IIncludableQueryable<Type, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Type? type = await _typeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return type;
    }

    public async Task<IPaginate<Type>?> GetListAsync(
        Expression<Func<Type, bool>>? predicate = null,
        Func<IQueryable<Type>, IOrderedQueryable<Type>>? orderBy = null,
        Func<IQueryable<Type>, IIncludableQueryable<Type, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Type> typeList = await _typeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return typeList;
    }

    public async Task<Type> AddAsync(Type type)
    {
        Type addedType = await _typeRepository.AddAsync(type);

        return addedType;
    }

    public async Task<Type> UpdateAsync(Type type)
    {
        Type updatedType = await _typeRepository.UpdateAsync(type);

        return updatedType;
    }

    public async Task<Type> DeleteAsync(Type type, bool permanent = false)
    {
        Type deletedType = await _typeRepository.DeleteAsync(type);

        return deletedType;
    }
}
