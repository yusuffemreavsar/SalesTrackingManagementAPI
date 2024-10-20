using Application.Features.Sales.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommand : IRequest<CreatedSaleResponse>
{
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreatedSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly SaleBusinessRules _saleBusinessRules;

        public CreateSaleCommandHandler(IMapper mapper, ISaleRepository saleRepository,
                                         SaleBusinessRules saleBusinessRules)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _saleBusinessRules = saleBusinessRules;
        }

        public async Task<CreatedSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Sale sale = _mapper.Map<Sale>(request);

            await _saleRepository.AddAsync(sale);

            CreatedSaleResponse response = _mapper.Map<CreatedSaleResponse>(sale);
            return response;
        }
    }
}