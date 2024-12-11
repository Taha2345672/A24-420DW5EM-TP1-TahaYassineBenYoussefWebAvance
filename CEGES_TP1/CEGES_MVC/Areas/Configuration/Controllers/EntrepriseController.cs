using CEGES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_MVC.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    public class EntrepriseController : Controller
    {

        public EntrepriseController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            await Task.CompletedTask;
            VM_Vide vm = new VM_Vide();
            if (id == null)
            {
                // Créer une nouvelle entreprise
            } 
            else
            {
                 // Récupérer l'entreprise existante
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(VM_Vide vm)
        {
            await Task.CompletedTask;
            if (ModelState.IsValid)
            {
                if (vm.Id == 0)
                {
                    // Ajouter l'entreprise
                }
                else
                {
                    // Modifier l'entreprise
                }
                return RedirectToAction(nameof(Details), new { id = vm.Id });
            }
            return View(vm);
        }
    }
}
