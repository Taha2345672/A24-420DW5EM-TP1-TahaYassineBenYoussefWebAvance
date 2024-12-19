using CEGES_DataAccess.data;
using CEGES_Models.ViewModels;
using CEGES_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_Service.IService
{
    public class EntrepriseService //:IEntrepriseService
    {
        private readonly CEGESDbContext _context;

        public EntrepriseService(CEGESDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListeEntreprisesVM>> GetEntreprisesAndCountsAsync()
        {
            return await _context.Entreprises
                .Select(e => new ListeEntreprisesVM
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Groupes = e.groupes.Count()
                })
                .ToListAsync();
        }

        public async Task<DetailEntrepriseVM> GetEntrepriseDetailAsync(int id)
        {
            var entreprise = await _context.Entreprises
                .Include(e => e.groupes)
                .ThenInclude(g => g.Equipements)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (entreprise == null) return null;

            return new DetailEntrepriseVM
            {
                Entreprise = entreprise,
                Groupes = entreprise.groupes.Select(g => new ListeGroupesVM
                {
                    Id = g.id,
                    Nom = g.Nom,
                    Equipements = g.Equipements.Count()
                }).ToList()
            };
        }

        public async Task<Entreprise> GetEntrepriseAsync(int id)
        {
            return await _context.Entreprises.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEntrepriseAsync(Entreprise entreprise)
        {
            await _context.Entreprises.AddAsync(entreprise);
            await _context.SaveChangesAsync();
        }

        public void UpdateEntreprise(Entreprise entreprise)
        {
            _context.Entreprises.Update(entreprise);
            _context.SaveChanges();
        }
    }
}
