using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers;

public class RoomController : Controller
{
    private IGatewayClient _gatewayClient;

    public RoomController(IGatewayClient gatewayClient)
    {
        _gatewayClient = gatewayClient;
    }

    public async Task<ActionResult> Index(DateTime dateStart, DateTime dateEnd)
    {
        var username = TempData["Username"];
        ViewData["Username"] = username;
        dateStart = dateStart.Equals(DateTime.MinValue) ? DateTime.Now : dateStart;
        dateEnd = dateEnd.Equals(DateTime.MinValue) ? DateTime.Now.AddDays(7) : dateEnd;

        IEnumerable<HabitacionesHabilitadasDto> habitacionesHabilitadas = await _gatewayClient.ObtenerHabitacionesHabilitadas(dateStart, dateEnd);

        HabitacionesViewModel habitaciones = new HabitacionesViewModel(habitacionesHabilitadas);
        habitaciones.DateStart = dateStart;
        habitaciones.DateEnd = dateEnd;

        return View(habitaciones);
    }

    public IActionResult Reservar(string? cabinCod, string? userName, string? dateStart, string? dateEnd)
    {
        if (string.IsNullOrWhiteSpace(cabinCod) 
            && string.IsNullOrWhiteSpace(userName)
            && string.IsNullOrWhiteSpace(dateStart)
            && string.IsNullOrWhiteSpace(dateEnd)) 
            return View("Index");
        TempData["cabinCod"] = cabinCod;
        TempData["userName"] = userName;
        TempData["dateStart"] = dateStart;
        TempData["dateEnd"] = dateEnd;

        return RedirectToAction("ConfirmBooking", "Booking");
    }
}