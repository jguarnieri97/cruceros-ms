using Cruceros.API.Reservas.Dto;
using Cruceros.API.Reservas.Services;
using Cruceros.Data.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Reservas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservasController : Controller
    {
        IReservasService _reservasService { get; set; }

        public ReservasController(IReservasService reservasService)
        {
            _reservasService = reservasService;
        }
        [HttpGet("ObtenerEntreFechas")]
        public IEnumerable<ReservasDto> GetReservasBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            Console.WriteLine($"Servicio: Reservas - INFO - Obteniendo reservas entre las fechas: {dateStart} - {dateEnd}");
            DateOnly dateFromOnly = DateOnly.FromDateTime(dateStart);
            DateOnly dateToOnly = DateOnly.FromDateTime(dateEnd);

            return _reservasService.GetReservasBetweenDates(dateFromOnly, dateToOnly);
        }

        [HttpPost("RealizarReserva")]
        public IActionResult RealizarReserva([FromBody] RealizarReservaDto realizarReservaDto)
        {
            try
            {
                _reservasService.RealizarReserva(realizarReservaDto);
                return Ok("Reserva realizada con exito");
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("VerificarReserva")]
        public IActionResult VerificarReserva([FromBody] ValidarReservaDto request)
        {
            Console.WriteLine($"Servicio: Reservas - INFO - Validando reserva: {request}");
            bool reservado = _reservasService.VerificarReserva(request);
            Console.WriteLine($"Servicio: Reservas - INFO - Verificación realizada.");
            return reservado ? Conflict("La habitación se encuentra reservada") : Ok("Se puede realizar la reserva");
        }
    }
}
