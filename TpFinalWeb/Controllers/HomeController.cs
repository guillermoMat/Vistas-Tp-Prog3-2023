using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using System.Web.Mvc;

using TpFinalWeb.Models;


namespace TpFinalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            ViewData["usuario"] = null;

            return RedirectToAction("Login", "Acceso");
        }
        public IActionResult BandejaEntrada()
        {
            return View();
        }
        public IActionResult ElementosEnviados()
        {
            return View();
        }
        public IActionResult EnviarCorreo()
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