using System.ComponentModel.DataAnnotations;

namespace Cruceros.MVC.Web.Models;

public class LoginModel
{
    [EmailAddress(ErrorMessage = "Email inválido")]
    [Required(ErrorMessage = "Inserte un email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Inserte una contraseña")]
    public string Password { get; set; }
}
