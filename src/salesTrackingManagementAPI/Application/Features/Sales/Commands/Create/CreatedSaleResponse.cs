using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sales.Commands.Create;

public class CreatedSaleResponse : IResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
}