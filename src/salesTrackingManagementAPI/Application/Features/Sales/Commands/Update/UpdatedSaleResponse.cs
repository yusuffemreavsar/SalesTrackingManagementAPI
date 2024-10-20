using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sales.Commands.Update;

public class UpdatedSaleResponse : IResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}