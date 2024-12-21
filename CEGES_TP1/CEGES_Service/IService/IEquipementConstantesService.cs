using CEGES_Models;
using CEGES_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Services;

public interface IEquipementConstantesService : IServiceBaseAsync<EquipementRelatives>
{
    Task<IReadOnlyList<EquipementConstantes>> GetByPeriodeAsync(int periode);
}
