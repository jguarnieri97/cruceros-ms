using Cruceros.MVC.Web.Dto;
using Cruceros.MVC.Web.Models;

namespace Cruceros.MVC.Web.Client;

public interface IAutenticationClient
{
    public void RegisterUser(RegisterUserDto request);
}

public class AutenticationClient : IAutenticationClient
{
    public void RegisterUser(RegisterUserDto request)
    {
        throw new NotImplementedException();
    }
}
