using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Dto;
using Cruceros.MVC.Web.Models;

namespace Cruceros.MVC.Web.Service;

public interface IUserService
{
    public void RegisterUser(RegisterModel model);
    public UserModel LoginUser(LoginModel model);
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
        _autenticationClient.RegisterUser(convertRegisterModelToDto(model));
    }

    public UserModel LoginUser(LoginModel model)
    {
        var response = _autenticationClient.LoginUser(converLoginModelToDto(model));
        
        while (!response.IsCompleted)
        {
            response.Wait();
        }
        var user = response.Result;
        //TODO: return username, save token in server

        return converResponseDtoToModel(user);
    }

    private RegisterUserDto convertRegisterModelToDto(RegisterModel model)
    {
        return new RegisterUserDto(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Username,
                model.Password
            );
    }

    private LoginRequestDto converLoginModelToDto(LoginModel model)
    {
        return new LoginRequestDto(model.Email, model.Password);
    }

    private UserModel converResponseDtoToModel(LoginResponseDto response)
    {
        return new UserModel(response.Username);
    }
}
