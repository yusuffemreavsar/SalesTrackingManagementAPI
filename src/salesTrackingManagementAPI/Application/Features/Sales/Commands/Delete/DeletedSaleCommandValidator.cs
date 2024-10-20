using FluentValidation;

namespace Application.Features.Sales.Commands.Delete;

public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
{
    public DeleteSaleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}