namespace Cruceros.API.Gateway.Dto;

public class TokenRequestDto
{
    public string Token { get; set; }

    public TokenRequestDto(string token)
    {
        Token = token;
    }
}
