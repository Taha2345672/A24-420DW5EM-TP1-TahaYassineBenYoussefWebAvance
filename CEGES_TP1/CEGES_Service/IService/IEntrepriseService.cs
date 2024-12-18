using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEGES_Models;
using CEGES_Models.ViewModels;

namespace CEGES_Service.IService
{
    public interface IEntrepriseService
    {
        Task<IEnumerable<EntrepriseViewModel>> GetEntreprisesSummaryAsync();

    }
}
