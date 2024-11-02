using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CruceroController : ControllerBase
{
    private ICruceroService _cruceroService;

    public CruceroController(ICruceroService cruceroService)
    {
        _cruceroService = cruceroService;
    }

    [HttpGet("prueba")]
    public IActionResult Prueba()
    {
        return Ok();
    }

    [HttpGet("ObtenerHabitacionesHabilitadas")]
    public async Task<IActionResult> GetRooms(DateTime dateStart, DateTime dateEnd)
    {
        var habitacionesDtos = await _cruceroService.GetHabitaciones();
        var reservasDtos = await _cruceroService.GetReservasBetweenDates(dateStart, dateEnd);

        List<HabitacionesHabilitadasDto> habitacionesHabilitadasDto = ConcatenerHabitacionesConReservas(habitacionesDtos, reservasDtos);
        return Ok(habitacionesHabilitadasDto);
    }

    [HttpPost("ReservarHabitacion")]
    public async Task<IActionResult> Reservar(ReservarHabitacionDto request)
    {
        var validarReserva = new ValidarReservaDto(request.CabinCod, request.DateStart, request.DateEnd);
        if (await _cruceroService.ValidarReserva(validarReserva))
        {
            var codigoReserva = Guid.NewGuid().ToString();
            await _cruceroService.RealizarReserva(new RealizarReservaDto(codigoReserva, request));
            return Ok("Reserva realizada con éxito!");
        }
        else
        {
            return Conflict("Reserva no válida");
        }
    }

    private List<HabitacionesHabilitadasDto> ConcatenerHabitacionesConReservas(IEnumerable<HabitacionesDto> habitacionesDtos, IEnumerable<ReservasDto> reservasDtos)
    {
        var habitacionesHabilitadas = new List<HabitacionesHabilitadasDto>();
        if (reservasDtos is not null)
        {
            habitacionesHabilitadas = habitacionesDtos.Select(h => new HabitacionesHabilitadasDto
            {
                Id = h.Id,
                CabinCod = h.CabinCod,
                Precio = h.Precio,
                TipoCabina = h.TipoCabina,
                Descripcion = h.Descripcion,
                Reservada = reservasDtos.Any(r => r.CabinCod == h.CabinCod)
            }).ToList();
            return habitacionesHabilitadas;
        }

        habitacionesHabilitadas = habitacionesDtos.Select(h => new HabitacionesHabilitadasDto
        {
            Id = h.Id,
            CabinCod = h.CabinCod,
            Precio = h.Precio,
            TipoCabina = h.TipoCabina,
            Descripcion = h.Descripcion,
            Reservada = false
        }).ToList();
        return habitacionesHabilitadas;


    }
}
