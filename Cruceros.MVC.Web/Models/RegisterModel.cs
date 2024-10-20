using System.ComponentModel.DataAnnotations;

namespace Cruceros.MVC.Web.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Inserte un nombre")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Inserte un apellido")]
    public string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido")]
    [Required(ErrorMessage = "Inserte un email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Inserte un nombre de usuario")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Inserte una contraseña")]
    public string Password { get; set; }

}
