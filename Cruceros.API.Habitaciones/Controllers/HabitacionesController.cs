using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Habitaciones.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Habitaciones.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        IHabitacionesService _habitacionesService { get; set; }

        public HabitacionesController(IHabitacionesService habitacionService)
        {
            _habitacionesService = habitacionService;
        }

        [HttpGet("ObtenerTodas")]
        public IEnumerable<HabitacionesDto> ObtenerTodas()
        {
            //TODO: intentar devolver el dto de la habitacion como A1, B2, etc
            return _habitacionesService.GetAll();
        }
    }
}
