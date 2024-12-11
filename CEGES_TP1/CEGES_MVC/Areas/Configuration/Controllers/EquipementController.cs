﻿using CEGES.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CEGES_MVC.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    public class EquipementController : Controller
    {


        public EquipementController()
        {

        }

        public async Task<IActionResult> Details(int id)
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> InsertType(int id)
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> Insert(int id, string type)
        {
            await Task.CompletedTask;
            VM_Vide vm = new VM_Vide();
            return View("Upsert", vm);
        }

        public async Task<IActionResult> Update(int id)
        {
            await Task.CompletedTask;
            VM_Vide vm = new VM_Vide();
            return View("Upsert", vm);
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
                    // Ajouter l'équipement
                }
                else
                {
                    // Mettre à jour l'équipement
                }
                return RedirectToAction(nameof(Details), new { id = vm.Id });
            }
            return View(vm);

        }
    }
}
