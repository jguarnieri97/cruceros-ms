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

        public ActionResult GetAll()
        {
            return View();
        }
    }
}