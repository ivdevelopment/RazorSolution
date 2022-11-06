using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Razor.Models;
using Razor.Services;
using System.Diagnostics;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FiliaalService _filiaalService;

        public HomeController(ILogger<HomeController> logger, FiliaalService filiaalService)
        {
            _logger = logger;
            _filiaalService = filiaalService;
        }

        public IActionResult Index()
        {
            return View(new Persoon { Voornaam = "Eddy", Familienaam = "Wally" });
        }

        public IActionResult Vestigingen()
        {
            Hoofdzetel deHoofdzetel = new Hoofdzetel
            {
                Straat = "Keizerslaan",
                HuisNr = "11",
                Postcode = "1000",
                Gemeente = "Brussel"
            };
            ViewBag.deHoofdzetel = deHoofdzetel;
            var recentVerwijderdFiliaal = (string?)this.TempData["filiaal"];
            if (recentVerwijderdFiliaal != null)
                ViewBag.recenteVerwijdering = JsonConvert.DeserializeObject<Filiaal?>(recentVerwijderdFiliaal)?.Naam;
            return View(_filiaalService.FindAll());
        }
        public IActionResult Verwijderd()
        {
            var tempdata = (string?)this.TempData.Peek("filiaal");
            if (tempdata != null)
            {
                Filiaal? filiaal = JsonConvert.DeserializeObject<Filiaal?>(tempdata);
                return View(filiaal);
            }
            else
                return Redirect("~/home/vestigingen");
        }
        public IActionResult Verwijderen(int id)
        {
            var filiaal = _filiaalService.Read(id);
            if (filiaal == null)
                ViewBag.filiaalnummer = id;
            return View(filiaal);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var filiaal = _filiaalService.Read(id);
            this.TempData["filiaal"] = JsonConvert.SerializeObject(filiaal);
            _filiaalService.Delete(id);
            return RedirectToAction(nameof(Verwijderd));
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