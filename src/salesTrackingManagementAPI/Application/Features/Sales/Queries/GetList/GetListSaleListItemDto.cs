using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
}