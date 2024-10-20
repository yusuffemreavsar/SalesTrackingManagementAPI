using Application.Features.Customers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Users.Constants;

namespace Application.Features.Customers.Rules;

public class CustomerBusinessRules : BaseBusinessRules
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public CustomerBusinessRules(ICustomerRepository customerRepository, ILocalizationService localizationService, IUserRepository userRepository)
    {
        _customerRepository = customerRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomerShouldExistWhenSelected(Customer? customer)
    {
        if (customer == null)
            await throwBusinessException(CustomersBusinessMessages.CustomerNotExists);
    }

    public async Task CustomerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerShouldExistWhenSelected(customer);
    }
    public async Task UserShouldExist(Guid userId)
    {
        var user = await _userRepository.GetAsync(
            predicate: user => user.Id == userId,
            enableTracking: false
            );

        if (user == null)
        {
            await throwBusinessException(UsersMessages.UserDontExists);
        }
    }
}