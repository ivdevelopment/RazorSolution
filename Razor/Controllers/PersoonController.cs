using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using Razor.Services;

namespace Razor.Controllers
{
    public class PersoonController : Controller
    {
        private readonly PersoonService _persoonService;
        public PersoonController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }

        public IActionResult Index()
        {
            return View(_persoonService.FindAll());
        }
        [HttpGet]
        public IActionResult VerwijderForm(int id)
        {
            Persoon? persoon = _persoonService.FindByID(id);
            if (persoon == null) ViewBag.id = id;
            return View(persoon);
        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new();
            opslagViewModel.Percentage = 10m;
            return View(opslagViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {
                // geen validatiefouten
                _persoonService.Opslag(opslagViewModel.VanWedde, opslagViewModel.TotWedde, opslagViewModel.Percentage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // wel validatiefouten
                return View(opslagViewModel);
            }
        }
        [HttpGet]
        public IActionResult VanTotWedde()
        {
            var vanTotWeddeViewModel = new VanTotWeddeViewModel();
            return View(vanTotWeddeViewModel);
        }

        [HttpGet]
        public IActionResult VanTotWeddeResultaat(VanTotWeddeViewModel vanTotWeddeViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var lijst = _persoonService.VanTotWedde(vanTotWeddeViewModel.VanWedde, vanTotWeddeViewModel.TotWedde);
                if (lijst.Count <= 3)
                    // geen extra probleem
                    vanTotWeddeViewModel.Personen = lijst;
                else
                    // wel een probleem
                    this.ModelState.AddModelError("", "Te veel resultaten");
            }
            return View(nameof(VanTotWedde), vanTotWeddeViewModel);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Score = 1;  // defaultwaarde voor een score
            return View(persoon);
        }

        [HttpPost]
        public IActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            Persoon? persoon = _persoonService.FindByID(id);
            if (persoon == null)
                return RedirectToAction(nameof(Index));
            else
                return View(persoon);
        }

        [HttpPost]
        public IActionResult Edit(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Update(p);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(nameof(EditForm), p);
            }
        }

        public IActionResult ValideerGebruikersnaam(string gebruikersnaam)
        {
            return Json(!_persoonService.Bestaat(gebruikersnaam));
        }
    }
}
