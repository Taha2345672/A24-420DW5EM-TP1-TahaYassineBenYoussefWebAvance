using CEGES_DataAccess;
using CEGES_Models;
using CEGES_Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGES_Service
{
    public class EquipementConstantesService : ServiceBase<EquipementConstantes>, IEquipementConstantesService
    {
        private readonly CEGESDbContext _dbContext;

        public EquipementConstantesService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EquipementConstantes> CreateAsync(EquipementConstantes entity)
        {
            await _dbContext.EquipementConstantes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var equipement = await _dbContext.EquipementConstantes.FindAsync(id);
            if (equipement != null)
            {
                _dbContext.EquipementConstantes.Remove(equipement);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<EquipementConstantes>> GetAllAsync()
        {
            return await _dbContext.EquipementConstantes.ToListAsync();
        }

        public async Task<EquipementConstantes?> GetByIdAsync(int id)
        {
            return await _dbContext.EquipementConstantes.FindAsync(id);
        }

        public async Task EditAsync(EquipementConstantes entity)
        {
            _dbContext.EquipementConstantes.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<EquipementConstantes>> GetByPeriodeAsync(int periode)
        {
            return await _dbContext.EquipementConstantes
                .Where(e => e.Periode == periode)
                .ToListAsync();
        }
    }
}
