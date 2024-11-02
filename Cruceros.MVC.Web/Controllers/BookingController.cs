using Cruceros.Data.Entidades;
using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers;

public class BookingController : Controller
{
    private IGatewayClient _gatewayClient;

    public BookingController(IGatewayClient gatewayClient)
    {
        _gatewayClient = gatewayClient;
    }

    public ActionResult BookingSuccess()
    {
        return View();
    }

    public ActionResult ConfirmBooking()
    {
        ViewData["cabinCod"] = TempData["cabinCod"];
        ViewData["userName"] = TempData["userName"];
        ViewData["dateStart"] = TempData["dateStart"];
        ViewData["dateEnd"] = TempData["dateEnd"];
        return View();
    }

    public ActionResult RegistrarReserva(ReservarHabitacionModel model) {
        if (ModelState.IsValid)
        {
            _gatewayClient.RegistrarReserva(model);
            return RedirectToAction("BookingSuccess");
        }
        return View("ConfirmBooking", model);
    }

}