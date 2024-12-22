using CEGES_DataAccess;
using CEGES_Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_Services
{
    public class EquipementRelativesService : ServiceBase<EquipementRelatives>, IEquipementRelativesService
    {
        private readonly CEGESDbContext _dbContext;

        public EquipementRelativesService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EquipementRelatives> CreateAsync(EquipementRelatives entity)
        {
            await _dbContext.EquipementRelatives.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var equipement = await _dbContext.EquipementRelatives.FindAsync(id);
            if (equipement != null)
            {
                _dbContext.EquipementRelatives.Remove(equipement);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<EquipementRelatives>> GetAllAsync()
        {
            return await _dbContext.EquipementRelatives.ToListAsync();
        }

        public async Task<EquipementRelatives?> GetByIdAsync(int id)
        {
            return await _dbContext.EquipementRelatives.FindAsync(id);
        }

        public async Task EditAsync(EquipementRelatives entity)
        {
            _dbContext.EquipementRelatives.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<EquipementRelatives>> GetByIntensiteMaxAsync(double intensiteMax)
        {
            return await _dbContext.EquipementRelatives
                .Where(e => e.IntesiteMax == intensiteMax)
                .ToListAsync();
        }
    }
}
