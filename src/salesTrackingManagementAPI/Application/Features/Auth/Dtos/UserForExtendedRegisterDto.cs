using NArchitecture.Core.Application.Dtos;


namespace Application.Features.Auth.Dtos;
public class UserForExtendedRegisterDto
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
