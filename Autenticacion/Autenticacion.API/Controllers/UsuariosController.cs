using Autenticacion.API.Dto;
using Autenticacion.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacion.API.Controllers;

[ApiController]
[Route("auth/api/[controller]")]
public class UsuariosController : ControllerBase
{

    IUsuariosService _usuariosService { get; set; }

    public UsuariosController(IUsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [HttpPost("crear")]
    public void Crear()
    {
        //method implementation
    }

    [HttpPost("login")]
    public LoginResponseDto Login(LoginRequestDto request)
    {
        return _usuariosService.loginUsuario(request);
    }
}
