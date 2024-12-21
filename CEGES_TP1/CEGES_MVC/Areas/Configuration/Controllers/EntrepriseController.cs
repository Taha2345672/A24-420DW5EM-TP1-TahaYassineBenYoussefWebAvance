using CEGES.Models;
using CEGES_Core.ViewModels;
using CEGES_Models.ViewModels;
using CEGES_MVC.Models;
using CEGES_Service.IService;
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

        public readonly IEntrepriseService _EntrepriseService;

        public EntrepriseController(IEntrepriseService EntrepriseService)
        {
            _EntrepriseService = EntrepriseService;
        }


        public async Task<IActionResult> Index()
        {
            List<ListeEntreprisesVM> vm = await _EntrepriseService.GetEntreprisesAndCountsAsync();
            return View(vm);
        }


        public async Task<IActionResult> Details(int id)
        {
           DetailEntrepriseVM vm = await _EntrepriseService.Configuration.GetEntrepriseDetailAsync(id);

            if (vm.Entreprise == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
           EntrepriseFormVM vm = new EntrepriseFormVM();
            if (id == null)
            {
                vm.Entreprise = new Entreprise();
            }
            else
            {
                vm.Entreprise = await _EntrepriseService.Configuration.GetEntrepriseAsync(id.GetValueOrDefault());
            }

            if (vm.Entreprise == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EntrepriseFormVM entrepriseVM)
        {
            if (ModelState.IsValid)
            {
                if (entrepriseVM.Entreprise.Id == 0)
                {
                    await _EntrepriseService.Configuration.AddEntrepriseAsync(entrepriseVM.Entreprise);
                }
                else
                {
                    _EntrepriseService.Configuration.UpdateEntreprise(entrepriseVM.Entreprise);
                }
                if (entrepriseVM.SelectAnalystes.Count > 3)
                {
                    // Message d'erreur "TROP D'ANALYSTES SÉLECTIONNÉS
                    return RedirectToAction(nameof(Upsert), new { id = entrepriseVM.Entreprise.Id });
                }
                try
                {
                    //await _EntrepriseService.Configuration.EditAnalystesEntrepriseAsync(entrepriseVM.Entreprise.Id, entrepriseVM.SelectAnalystes);
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Upsert), new { id = entrepriseVM.Entreprise.Id });
                }
                return RedirectToAction(nameof(Details), new { id = entrepriseVM.Entreprise.Id });
            }
            return View(entrepriseVM);
        }
    }
}
