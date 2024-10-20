using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Product: Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public ICollection<Sale>? Sales { get; set; }
}
