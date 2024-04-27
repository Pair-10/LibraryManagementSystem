using Application.Features.MaterialPublishers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaterialPublishers;

public class MaterialPublisherManager : IMaterialPublisherService
{
    private readonly IMaterialPublisherRepository _materialPublisherRepository;
    private readonly MaterialPublisherBusinessRules _materialPublisherBusinessRules;

    public MaterialPublisherManager(IMaterialPublisherRepository materialPublisherRepository, MaterialPublisherBusinessRules materialPublisherBusinessRules)
    {
        _materialPublisherRepository = materialPublisherRepository;
        _materialPublisherBusinessRules = materialPublisherBusinessRules;
    }

    public async Task<MaterialPublisher?> GetAsync(
        Expression<Func<MaterialPublisher, bool>> predicate,
        Func<IQueryable<MaterialPublisher>, IIncludableQueryable<MaterialPublisher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaterialPublisher? materialPublisher = await _materialPublisherRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return materialPublisher;
    }

    public async Task<IPaginate<MaterialPublisher>?> GetListAsync(
        Expression<Func<MaterialPublisher, bool>>? predicate = null,
        Func<IQueryable<MaterialPublisher>, IOrderedQueryable<MaterialPublisher>>? orderBy = null,
        Func<IQueryable<MaterialPublisher>, IIncludableQueryable<MaterialPublisher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaterialPublisher> materialPublisherList = await _materialPublisherRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return materialPublisherList;
    }

    public async Task<MaterialPublisher> AddAsync(MaterialPublisher materialPublisher)
    {
        MaterialPublisher addedMaterialPublisher = await _materialPublisherRepository.AddAsync(materialPublisher);

        return addedMaterialPublisher;
    }

    public async Task<MaterialPublisher> UpdateAsync(MaterialPublisher materialPublisher)
    {
        MaterialPublisher updatedMaterialPublisher = await _materialPublisherRepository.UpdateAsync(materialPublisher);

        return updatedMaterialPublisher;
    }

    public async Task<MaterialPublisher> DeleteAsync(MaterialPublisher materialPublisher, bool permanent = false)
    {
        MaterialPublisher deletedMaterialPublisher = await _materialPublisherRepository.DeleteAsync(materialPublisher);

        return deletedMaterialPublisher;
    }
}
