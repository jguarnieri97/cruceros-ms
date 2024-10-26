namespace Cruceros.MVC.Web.Models;

public class UserModel
{
    public string Username { get; set; }

    public UserModel(string username)
    {
        Username = username;
    }
}
