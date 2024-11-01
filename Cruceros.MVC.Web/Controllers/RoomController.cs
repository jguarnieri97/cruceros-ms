using Cruceros.API.Gateway.Services;
using Cruceros.API.Habitaciones.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public ActionResult GetAll()
        {
            return View();
        }
    }
}