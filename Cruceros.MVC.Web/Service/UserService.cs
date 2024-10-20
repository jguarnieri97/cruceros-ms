using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Dto;
using Cruceros.MVC.Web.Models;

namespace Cruceros.MVC.Web.Service;

public interface IUserService
{
    public void RegisterUser(RegisterModel model);
}

public class UserService : IUserService
{
    private IAutenticationClient _autenticationClient;

    public UserService(IAutenticationClient autenticationClient)
    {
        _autenticationClient = autenticationClient;
    }

    public void RegisterUser(RegisterModel model)
    {
        _autenticationClient.RegisterUser(convertModelToDto(model));
    }

    private RegisterUserDto convertModelToDto(RegisterModel model)
    {
        return new RegisterUserDto(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Username,
                model.Password
            );
    }
}
