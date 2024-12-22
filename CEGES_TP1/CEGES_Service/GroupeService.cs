using CEGES_DataAccess;
using CEGES_Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_Services
{
    public class GroupeService : ServiceBase<Groupe>, IGroupeService
    {
        private readonly CEGESDbContext _dbContext;

        public GroupeService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Groupe> CreateAsync(Groupe entity)
        {
            await _dbContext.Groupes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var groupe = await _dbContext.Groupes.FindAsync(id);
            if (groupe != null)
            {
                _dbContext.Groupes.Remove(groupe);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<Groupe>> GetAllAsync()
        {
            return await _dbContext.Groupes.ToListAsync();
        }

        public async Task<Groupe?> GetByIdAsync(int id)
        {
            return await _dbContext.Groupes.FindAsync(id);
        }

        public async Task EditAsync(Groupe entity)
        {
            _dbContext.Groupes.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Groupe>> GetByEntrepriseIdAsync(int entrepriseId)
        {
            return await _dbContext.Groupes.Where(g => g.EntrepriseId == entrepriseId).ToListAsync();
        }
    }
}
