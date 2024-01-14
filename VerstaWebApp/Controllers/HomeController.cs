using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VerstaWebApp.Models;

namespace VerstaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { StatusCode = Response.StatusCode });
        }
    }
}
