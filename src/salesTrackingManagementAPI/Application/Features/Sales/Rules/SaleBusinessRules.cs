using Application.Features.Sales.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;
using Application.Features.Products.Constants;

namespace Application.Features.Sales.Rules;

public class SaleBusinessRules : BaseBusinessRules
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public SaleBusinessRules(ISaleRepository saleRepository, ILocalizationService localizationService, IUserRepository userRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
        _productRepository = productRepository;
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

    public async Task UserShouldExist(Guid userId)
    {
        var user = await _userRepository.GetAsync(
            predicate: user => user.Id == userId,
            enableTracking: false
            );

        if(user == null)
        {
            await throwBusinessException(UsersMessages.UserDontExists);
        }
    }
    public async Task ProductShouldExist(Guid productId)
    {
        var product = await _productRepository.GetAsync(
            predicate: product => product.Id == productId,
            enableTracking: false
            );

        if (product == null)
        {
            await throwBusinessException(ProductsBusinessMessages.ProductNotExists);
        }
    }



}