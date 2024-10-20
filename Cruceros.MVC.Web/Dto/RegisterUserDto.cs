using System.ComponentModel.DataAnnotations;

namespace Cruceros.MVC.Web.Dto;

public class RegisterUserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public RegisterUserDto(string firstName, string lastName, string email, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Username = username;
        Password = password;
    }
}
