using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CEGES_Models.ViewModels;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using CEGES_Models;
using System;
using CEGES_Services;


namespace CEGES_Areas.Configuration.Controllers
{
    [Area("Configuration")]
    public class EntrepriseController : Controller
    {
        private readonly IEntrepriseService _entrepriseService;
        private readonly IGroupeService _groupeService;
        private readonly IEquipementConstantesService _equipementConstantesService;
        private readonly IEquipementLineairesService _equipementLineairesService;
        private readonly IEquipementRelativesService _equipementRelativesService;


        public EntrepriseController(IEntrepriseService entrepriseService, IGroupeService groupeService, IEquipementConstantesService equipementConstantesService, IEquipementLineairesService equipementLineairesService, IEquipementRelativesService equipementRelativesService)
        {
            _entrepriseService = entrepriseService;
            _groupeService = groupeService;
            _equipementConstantesService = equipementConstantesService;
            _equipementLineairesService = equipementLineairesService;
            _equipementRelativesService = equipementRelativesService;
        }

        public async Task<IActionResult> Index()
        {
            var entreprise = await _entrepriseService.GetAllIndexAsync();
            var entrepriseVM = entreprise.Select(entreprise => new Entreprise_VM
            {
                Entreprise = entreprise,
                NombreGroupes = entreprise.Groupes.Count(),
                NombreEquipement = entreprise.Groupes.SelectMany(g => g.Equipements).Count(),
                NombrePeriodesMesurees = entreprise.Groupes.SelectMany(g => g.Equipements).Sum(e => e.Periode)

            }).OrderBy(entrepriseVM => entrepriseVM.Entreprise.NomEntreprise);

            return View(entrepriseVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            await Task.CompletedTask;

            return View(await _entrepriseService.GetEntrepriseByIdAsync(id));
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Entreprise_VM vm = new Entreprise_VM();

            if (id == null)
            {
                
                return View(vm);
            }
            else
            {
                
                var entreprise = await _entrepriseService.GetEntrepriseByIdAsync(id.Value);
                if (vm.Entreprise == null)
                {
                    return NotFound(); 
                }

                vm.Entreprise = entreprise;

                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Entreprise_VM vm)
        {
            if (ModelState.IsValid)
            {

                if (vm.Entreprise.Id == 0)
                {
                    // il faut creer validation Entreprise UNIQUE (GA)
                    await _entrepriseService.AddEntrepriseAsync(vm.Entreprise);
                }
                else
                {
                    
                    await _entrepriseService.EditAsync(vm.Entreprise);
                }
                return RedirectToAction(nameof(Details), new { id = vm.Entreprise.Id });
            }
            return View(vm);
        }

    }
}
