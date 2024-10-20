using FluentValidation;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Customer).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Product).NotEmpty();
    }
}