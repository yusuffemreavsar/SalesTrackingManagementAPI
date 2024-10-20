using Application.Features.Sales.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sales;

public class SaleManager : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly SaleBusinessRules _saleBusinessRules;

    public SaleManager(ISaleRepository saleRepository, SaleBusinessRules saleBusinessRules)
    {
        _saleRepository = saleRepository;
        _saleBusinessRules = saleBusinessRules;
    }

    public async Task<Sale?> GetAsync(
        Expression<Func<Sale, bool>> predicate,
        Func<IQueryable<Sale>, IIncludableQueryable<Sale, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Sale? sale = await _saleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sale;
    }

    public async Task<IPaginate<Sale>?> GetListAsync(
        Expression<Func<Sale, bool>>? predicate = null,
        Func<IQueryable<Sale>, IOrderedQueryable<Sale>>? orderBy = null,
        Func<IQueryable<Sale>, IIncludableQueryable<Sale, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Sale> saleList = await _saleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return saleList;
    }

    public async Task<Sale> AddAsync(Sale sale)
    {
        Sale addedSale = await _saleRepository.AddAsync(sale);

        return addedSale;
    }

    public async Task<Sale> UpdateAsync(Sale sale)
    {
        Sale updatedSale = await _saleRepository.UpdateAsync(sale);

        return updatedSale;
    }

    public async Task<Sale> DeleteAsync(Sale sale, bool permanent = false)
    {
        Sale deletedSale = await _saleRepository.DeleteAsync(sale);

        return deletedSale;
    }
}
