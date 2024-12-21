
using CEGES_DataAccess;
using CEGES_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Services
{
    public class EquipementLineairesService : ServiceBase<EquipementLineaires>, IEquipementLineairesService
    {
        private readonly CEGESDbContext _dbContext;
        public EquipementLineairesService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<IReadOnlyList<EquipementLineaires>> GetByUniteMesureAsync(string uniteMesure)
        {
            return await _dbContext.EquipementLineaires.Where(e => e.UniteMesure == uniteMesure).ToListAsync();
        }
    }
}
