using Cruceros.Data.Entidades;
using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers;

public class BookingController : Controller
{
    

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
            //TODO: service y cliente
        }
        return View("ConfirmBooking", model);
    }

}