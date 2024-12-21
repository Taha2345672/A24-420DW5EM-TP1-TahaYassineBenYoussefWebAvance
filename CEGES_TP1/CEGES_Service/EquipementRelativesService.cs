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
    public class EquipementRelativesService : ServiceBase<EquipementRelativesService>//, IEquipementRelativesService
    {
        public readonly CEGESDbContext _dbContext;
        public EquipementRelativesService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task<IReadOnlyList<EquipementRelatives>> GetByIntensiteMaxAsync(double IntensiteMax)
        {
            return await _dbContext.EquipementRelatives.Where(e=> e.IntesiteMax ==  IntensiteMax).ToListAsync();
        }

       
    }

}
