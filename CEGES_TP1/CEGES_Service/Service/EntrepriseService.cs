using CEGES_DataAccess;
using CEGES.Models;
using CEGES_Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEGES_DataAccess.data;
using CEGES_Models.ViewModels;

public class EntrepriseService : IEntrepriseService
{
    private readonly CEGESDbContext _context;

    public EntrepriseService(CEGESDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EntrepriseViewModel>> GetEntreprisesSummaryAsync()
    {
        return await _context.Entreprises
            .Select(e => new EntrepriseViewModel
            {
                Nom = e.Nom,
                NombreGroupes = e.groupes.Count(),
                NombreEquipements = e.groupes.SelectMany(g => g.Equipements).Count(),
                NombrePeriodesMesurees = e.groupes.SelectMany(g => g.Periodes).Distinct().Count()
            })
            .OrderBy(e => e.Nom)
            .ToListAsync();
    }
}
