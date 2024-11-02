using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class RoomController : Controller
    {
        private IGatewayClient _gatewayClient;

        public RoomController(IGatewayClient gatewayClient)
        {
            _gatewayClient = gatewayClient;
        }

        public async Task<ActionResult> Index(DateTime dateStart, DateTime dateEnd)
        {
            dateStart = dateStart.Equals(DateTime.MinValue) ? DateTime.Now : dateStart;
            dateEnd = dateEnd.Equals(DateTime.MinValue) ? DateTime.Now.AddDays(7) : dateEnd;

            IEnumerable<HabitacionesHabilitadasDto> habitacionesHabilitadas = await _gatewayClient.ObtenerHabitacionesHabilitadas(dateStart, dateEnd);

            HabitacionesViewModel habitaciones = new HabitacionesViewModel(habitacionesHabilitadas);
            habitaciones.DateStart = dateStart;
            habitaciones.DateEnd = dateEnd;

            return View(habitaciones);
        }
    }
}