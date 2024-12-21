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
    public class GroupeService : ServiceBase<GroupeService>//, IGroupeService
    {
        private readonly CEGESDbContext _dbContext;
        public GroupeService(CEGESDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<IReadOnlyList<Groupe>> GetByEntrepriseIdAsync(int entrepriseId)
        {
            return await _dbContext.Groupes.Where(g => g.EntrepriseId == entrepriseId).ToListAsync();
        }
    }
}
