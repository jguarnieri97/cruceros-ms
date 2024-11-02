using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Models;
using Cruceros.MVC.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers;

public class BookingController : Controller
{
    private IGatewayClient _gatewayClient;
    private ISessionContext _sessionContext;

    public BookingController(IGatewayClient gatewayClient, ISessionContext sessionContext)
    {
        _gatewayClient = gatewayClient;
        _sessionContext = sessionContext;
    }

    public ActionResult BookingSuccess()
    {
        ViewData["Username"] = _sessionContext.GetSessionUser();
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

    public async Task<ActionResult> RegistrarReserva(ReservarHabitacionModel model) {
        if (ModelState.IsValid)
        {
            await _gatewayClient.RegistrarReserva(model);
            return RedirectToAction("BookingSuccess");
        }
        return View("ConfirmBooking", model);
    }

}