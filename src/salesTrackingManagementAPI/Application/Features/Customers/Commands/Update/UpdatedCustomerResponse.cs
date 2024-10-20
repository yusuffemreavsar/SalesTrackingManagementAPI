using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Update;

public class UpdatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? PhoneNumber { get; set; }
}