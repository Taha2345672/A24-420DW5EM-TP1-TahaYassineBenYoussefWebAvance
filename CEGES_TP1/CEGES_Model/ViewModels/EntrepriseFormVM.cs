using CEGES_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
 public class EntrepriseFormVM
    {
        public Entreprise Entreprise { get; set; }
      
        public List<string> SelectAnalystes { get; set; }
    }
}
