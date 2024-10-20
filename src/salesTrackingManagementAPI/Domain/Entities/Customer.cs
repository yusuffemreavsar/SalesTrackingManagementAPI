using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Customer: Entity<Guid>
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Sale>? Sales { get; set; }
}
