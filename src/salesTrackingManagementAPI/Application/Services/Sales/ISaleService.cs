using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sales;

public interface ISaleService
{
    Task<Sale?> GetAsync(
        Expression<Func<Sale, bool>> predicate,
        Func<IQueryable<Sale>, IIncludableQueryable<Sale, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Sale>?> GetListAsync(
        Expression<Func<Sale, bool>>? predicate = null,
        Func<IQueryable<Sale>, IOrderedQueryable<Sale>>? orderBy = null,
        Func<IQueryable<Sale>, IIncludableQueryable<Sale, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Sale> AddAsync(Sale sale);
    Task<Sale> UpdateAsync(Sale sale);
    Task<Sale> DeleteAsync(Sale sale, bool permanent = false);
}
