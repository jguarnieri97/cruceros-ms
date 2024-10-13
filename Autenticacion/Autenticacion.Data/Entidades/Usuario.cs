using System;
using System.Collections.Generic;

namespace Autenticacion.Data.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Usuario(string userName, string email, string firstName, string lastName, string password)
    {
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }
}
