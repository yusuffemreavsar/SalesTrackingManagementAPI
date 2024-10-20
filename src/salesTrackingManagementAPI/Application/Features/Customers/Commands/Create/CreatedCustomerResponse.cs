using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? PhoneNumber { get; set; }
}