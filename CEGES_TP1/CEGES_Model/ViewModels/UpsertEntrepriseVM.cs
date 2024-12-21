
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
    public class UpsertEntrepriseVM
    {
        public Entreprise Entreprise { get; set; }
       // public List<SelectListItem> Analystes { get; set; }
        public List<string> SelectAnalystes { get; set; }
    }
}
