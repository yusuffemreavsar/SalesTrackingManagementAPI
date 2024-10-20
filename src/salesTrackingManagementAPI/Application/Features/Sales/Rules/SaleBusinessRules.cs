using Application.Features.Sales.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Sales.Rules;

public class SaleBusinessRules : BaseBusinessRules
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILocalizationService _localizationService;

    public SaleBusinessRules(ISaleRepository saleRepository, ILocalizationService localizationService)
    {
        _saleRepository = saleRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SalesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SaleShouldExistWhenSelected(Sale? sale)
    {
        if (sale == null)
            await throwBusinessException(SalesBusinessMessages.SaleNotExists);
    }

    public async Task SaleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Sale? sale = await _saleRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SaleShouldExistWhenSelected(sale);
    }
}