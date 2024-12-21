using CEGES_Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEGES_Services
{
    public interface IEquipementConstantesService : IServiceBaseAsync<EquipementConstantes>
    {
        Task<IReadOnlyList<EquipementConstantes>> GetByPeriodeAsync(int periode);
    }
}
