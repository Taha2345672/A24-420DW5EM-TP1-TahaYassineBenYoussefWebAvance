using CEGES_DataAccess;
using CEGES_Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using CEGES_Services;


namespace CEGES_Services;

public class EntrepriseService : ServiceBase<Entreprise>, IEntrepriseService
{ 
    private readonly CEGESDbContext _dbContext;

    public EntrepriseService(CEGESDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Entreprise>> GetAllIndexAsync()
    {
        //return await _dbContext.Set<Entreprise>().OrderBy(z => z.NomEntreprise).ToListAsync();
        return await _dbContext.Entreprises
       .Include(e => e.Groupes) 
       .ThenInclude(g => g.Equipements).OrderBy(z => z.NomEntreprise)
       .ToListAsync();
    }
    public async Task<Entreprise> GetEntrepriseByIdAsync(int id)
    {
        return await _dbContext.Entreprises
            .Include(e => e.Groupes)
            .ThenInclude(g => g.Equipements)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IReadOnlyList<Entreprise>> GetAllEntreprisesByIdAsync(int id)
    {
        return null;
    }


    public async Task AddEntrepriseAsync(Entreprise entreprise)
    {
        await CreateAsync(entreprise);
    }

    public async Task EditAsync(Entreprise entreprise)
    {
        await base.EditAsync(entreprise);
    }


}
