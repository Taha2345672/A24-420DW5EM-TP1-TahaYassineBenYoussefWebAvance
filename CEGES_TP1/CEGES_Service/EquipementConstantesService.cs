using CEGES_DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEGES_Services;
using CEGES_Models;



namespace CEGES_Services;

public class EquipementConstantesService : ServiceBase<EquipementConstantesService> ,IEquipementConstantesService
{
    public readonly CEGESDbContext _dbContext;
    public EquipementConstantesService(CEGESDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

   
    public async Task<IReadOnlyList<EquipementConstantes>> GetByPeriodeAsync(int periode)
    {
        return await _dbContext.EquipementConstantes.Where(e => e.Periode == periode).ToListAsync();
    }
}
