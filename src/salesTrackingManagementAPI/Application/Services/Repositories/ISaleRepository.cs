using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISaleRepository : IAsyncRepository<Sale, Guid>, IRepository<Sale, Guid>
{
}