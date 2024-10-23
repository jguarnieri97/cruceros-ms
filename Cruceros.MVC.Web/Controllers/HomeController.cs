using Cruceros.MVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Cruceros.Data.Entidades;
using Cruceros.MVC.Web.Client;

namespace Cruceros.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGatewayClient _gatewayClient;

        public HomeController(ILogger<HomeController> logger, IGatewayClient gatewayClient)
        {
            _logger = logger;
            _gatewayClient = gatewayClient;
        }

        public IActionResult Index()
        {
            var username = TempData["Username"];
            ViewData["Username"] = username;

            _gatewayClient.Prueba(username.ToString());

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
