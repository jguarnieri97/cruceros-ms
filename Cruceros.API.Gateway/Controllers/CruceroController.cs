using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CruceroController : ControllerBase
{
    [HttpGet("prueba")]
    public IActionResult Prueba()
    {
        return Ok();
    }

}
