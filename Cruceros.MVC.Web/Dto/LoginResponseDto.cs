namespace Cruceros.MVC.Web.Dto;

public class LoginResponseDto
{
    public string Username { get; set; }
    public string Token { get; set; }

    public LoginResponseDto(string username, string token)
    {
        Username = username;
        Token = token;
    }
}
