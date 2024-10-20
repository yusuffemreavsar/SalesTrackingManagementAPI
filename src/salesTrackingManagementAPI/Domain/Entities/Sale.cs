using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Sale: Entity<Guid>
{
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
