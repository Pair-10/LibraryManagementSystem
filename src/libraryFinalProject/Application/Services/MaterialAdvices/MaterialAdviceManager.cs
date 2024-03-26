using Application.Features.MaterialAdvices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialAdvices;

public class MaterialAdviceManager : IMaterialAdviceService
{
    private readonly IMaterialAdviceRepository _materialAdviceRepository;
    private readonly MaterialAdviceBusinessRules _materialAdviceBusinessRules;

    public MaterialAdviceManager(IMaterialAdviceRepository materialAdviceRepository, MaterialAdviceBusinessRules materialAdviceBusinessRules)
    {
        _materialAdviceRepository = materialAdviceRepository;
        _materialAdviceBusinessRules = materialAdviceBusinessRules;
    }

    public async Task<MaterialAdvice?> GetAsync(
        Expression<Func<MaterialAdvice, bool>> predicate,
        Func<IQueryable<MaterialAdvice>, IIncludableQueryable<MaterialAdvice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialAdvice? materialAdvice = await _materialAdviceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialAdvice;
    }

    public async Task<IPaginate<MaterialAdvice>?> GetListAsync(
        Expression<Func<MaterialAdvice, bool>>? predicate = null,
        Func<IQueryable<MaterialAdvice>, IOrderedQueryable<MaterialAdvice>>? orderBy = null,
        Func<IQueryable<MaterialAdvice>, IIncludableQueryable<MaterialAdvice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialAdvice> materialAdviceList = await _materialAdviceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialAdviceList;
    }

    public async Task<MaterialAdvice> AddAsync(MaterialAdvice materialAdvice)
    {
        MaterialAdvice addedMaterialAdvice = await _materialAdviceRepository.AddAsync(materialAdvice);

        return addedMaterialAdvice;
    }

    public async Task<MaterialAdvice> UpdateAsync(MaterialAdvice materialAdvice)
    {
        MaterialAdvice updatedMaterialAdvice = await _materialAdviceRepository.UpdateAsync(materialAdvice);

        return updatedMaterialAdvice;
    }

    public async Task<MaterialAdvice> DeleteAsync(MaterialAdvice materialAdvice, bool permanent = false)
    {
        MaterialAdvice deletedMaterialAdvice = await _materialAdviceRepository.DeleteAsync(materialAdvice);

        return deletedMaterialAdvice;
    }
}
