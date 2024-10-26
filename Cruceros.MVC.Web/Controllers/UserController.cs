using Cruceros.MVC.Web.Models;
using Cruceros.MVC.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.MVC.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        public ActionResult RegisterUser(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(user);
                return View("Login");
            }
            return View("SignUp", user);
        }

        public ActionResult SignIn(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LoginUser(login);
                TempData["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
            return View("Login", login);
        }
    }
}
