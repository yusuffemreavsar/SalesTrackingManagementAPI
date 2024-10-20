using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SaleRepository : EfRepositoryBase<Sale, Guid, BaseDbContext>, ISaleRepository
{
    public SaleRepository(BaseDbContext context) : base(context)
    {
    }
}