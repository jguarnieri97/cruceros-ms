using Cruceros.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class UserController : Controller
    {
        private CrucerosContext _ctx;

        public UserController(CrucerosContext ctx)
        {
            _ctx = ctx;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }
    }
}
