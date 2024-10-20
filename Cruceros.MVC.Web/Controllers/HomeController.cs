using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Cruceros.Data.Entidades;

namespace Cruceros.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CrucerosContext _ctx;

        public HomeController(ILogger<HomeController> logger, CrucerosContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
