using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Reservas.Dto;
using Cruceros.Data.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Gateway.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CruceroController : ControllerBase
{
    private IRoomService _roomService;

    public CruceroController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet("prueba")]
    public IActionResult Prueba()
    {
        return Ok();
    }

    [HttpGet("ObtenerHabitacionesHabilitadas")]
    public IActionResult GetRooms(DateTime dateStar, DateTime dateEnd)
    {
        var habitacionesDtos = _roomService.GetHabitaciones();
        var reservasDtos = _roomService.GetReservasBetweenDates(dateStar, dateEnd);

        List<HabitacionesHabilitadasDto> habitacionesHabilitadasDto = ConcatenerHabitacionesConReservas(habitacionesDtos, reservasDtos);
        return Ok(habitacionesHabilitadasDto);
    }

    private List<HabitacionesHabilitadasDto> ConcatenerHabitacionesConReservas(IEnumerable<HabitacionesDto> habitacionesDtos, IEnumerable<ReservasDto> reservasDtos)
    {
        var habitacionesHabilitadas = habitacionesDtos.Select(h => new HabitacionesHabilitadasDto
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
}
