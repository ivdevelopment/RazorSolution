using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System.Diagnostics;

namespace Razor.Controllers
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
            return View(new Persoon { Voornaam = "Eddy", Familienaam = "Wally" });
        }

        // Werknemer
        [ActionName("Werknemerslijst")]
        public IActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer { Voornaam = "Steven", Wedde = 1000m, Indienst = DateTime.Today });
            werknemers.Add(new Werknemer { Voornaam = "Prosper", Wedde = 2000m, Indienst = DateTime.Today.AddDays(2) });
            return View("AlleWerknemers", werknemers);
        }

        // Palindroom oefening
        public IActionResult Palindroom(string woord)
        {
            char[] woordAlsCharArray = woord.ToCharArray();
            Array.Reverse(woordAlsCharArray);
            string omgekeerd = new string(woordAlsCharArray);
            ViewBag.palindroom = woord == omgekeerd;
            ViewBag.ingetiktwoord = woord;
            return View();
        }

        // Fibonacci Oefening
        public IActionResult Fibonacci()
        {
            return View();
        }

        public IActionResult Privacy()
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