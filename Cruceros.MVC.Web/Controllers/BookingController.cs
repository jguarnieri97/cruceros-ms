using Cruceros.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class BookingController : Controller
    {
        private CrucerosContext _ctx;

        public BookingController(CrucerosContext ctx)
        {
            _ctx = ctx;
        }

        public ActionResult BookingSuccess()
        {
            return View();
        }

        public ActionResult ConfirmBooking()
        {
            return RedirectToAction("ConfirmBooking");
        }

    }
}
