
using System.Collections.Generic;
using CEGES_Models;
using CEGES_MVC.Models;

namespace CEGES_Core.ViewModels
{
    public class UpsertEntrepriseVM
    {
        public Entreprise Entreprise { get; set; }
       // public List<SelectListItem> Analystes { get; set; }
        public List<string> SelectAnalystes { get; set; }
    }
}
