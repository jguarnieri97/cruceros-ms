using Cruceros.API.Gateway.Dto;
using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly ICruceroService _roomService;

        public RoomController(ICruceroService roomService)
        {
            _roomService = roomService;
        }

        public ActionResult Index(DateTime? dateStart, DateTime? dateEnd)
        {
            dateStart ??= DateTime.Today;
            dateEnd ??= DateTime.Today.AddDays(7);

            //TO DO: aca implementar llamada a la api gateway 
            IEnumerable<HabitacionesHabilitadasDto> habitaciones = null;  

            return View(habitaciones);
        }
    }
}