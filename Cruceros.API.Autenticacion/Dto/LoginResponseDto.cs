namespace Cruceros.API.Autenticacion.Dto;

public class LoginResponseDto
{
    public LoginResponseDto(string username, string token)
    {
        Username = username;
        Token = token;
    }

    public string Username { get; set; }
    public string Token { get; set; }
}

