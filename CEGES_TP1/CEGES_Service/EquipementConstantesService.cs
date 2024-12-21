using CEGES_DataAccess;
using CEGES_Models;
using CEGES_Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CEGES_Service
{
   public class EquipementConstantesService : ServiceBase<EquipementConstantesService>//, IEquipementConstantesService
    {
        private readonly CEGESDbContext _dbContext;

        public EquipementConstantesService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Implémentation de CreateAsync pour EquipementConstantes
        public async Task<EquipementConstantes> CreateAsync(EquipementConstantes entity)
        {
            await _dbContext.EquipementConstantes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        // Méthode pour récupérer les EquipementConstantes par Période
        public async Task<IReadOnlyList<EquipementConstantes>> GetByPeriodeAsync(int periode)
        {
            return await _dbContext.EquipementConstantes.Where(e => e.Periode == periode).ToListAsync();
        }
    }
}

   
