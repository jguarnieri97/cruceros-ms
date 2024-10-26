using Cruceros.API.Autenticacion.Dto;
using Cruceros.API.Autenticacion.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Autenticacion.Controllers;

[ApiController]
[Route("auth/api/[controller]")]
public class TokenController : ControllerBase
{
    private ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("validate")]
    public void Validate(TokenRequestDto request)
    {
        _tokenService.validateToken(request.Token);
    }

    [HttpGet("create")]
    public LoginResponseDto Create(string userName)
    {
        var token = _tokenService.createToken(userName);
        return new LoginResponseDto(userName, token);
    }
}
