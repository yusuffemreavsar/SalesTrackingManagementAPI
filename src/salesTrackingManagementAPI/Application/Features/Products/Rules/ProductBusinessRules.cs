using Application.Features.Products.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;
    private readonly ILocalizationService _localizationService;

    public ProductBusinessRules(IProductRepository productRepository, ILocalizationService localizationService)
    {
        _productRepository = productRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            await throwBusinessException(ProductsBusinessMessages.ProductNotExists);
    }

    public async Task ProductIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductShouldExistWhenSelected(product);
    }
}