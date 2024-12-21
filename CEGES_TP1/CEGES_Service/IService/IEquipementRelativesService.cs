using CEGES_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CEGES_Services;


public interface IEquipementRelativesService : IServiceBaseAsync<EquipementRelatives>
{
    Task<IReadOnlyList<EquipementRelatives>> GetByIntensiteMaxAsync(double IntensiteMax);
}
