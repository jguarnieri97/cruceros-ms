using Cruceros.API.Autenticacion.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cruceros.API.Autenticacion.Service;

public interface ITokenService
{
    string createToken(string userName);
    void validateToken(string token);
}

public class TokenService : ITokenService
{
    private static List<string> _sessions;

    public TokenService()
    {
        if(_sessions == null)
        {
            _sessions = new List<string>();
        }
    }

    public string createToken(string userName)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BkEYRfohz6uWST1MCjB7eHhzdeYgggYjLCawt3DTt1VnHDH/74dbqczsOZ+p7IfI\r\n"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                issuer: "Cruceros",
                audience: "https://localhost:8080",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        _sessions.Add(jwt.ToString());

        return jwt.ToString();
    }

    public void validateToken(string token)
    {
        var tk = _sessions.Find(x => x.Equals(token));

        if (tk.IsNullOrEmpty()) throw new TokenNotFoundException();
        var handler = new JwtSecurityTokenHandler();
        var sToken = handler.ReadToken(token);

        if (sToken.ValidTo < DateTime.Now) throw new TokenExpiredException();
    }
}
