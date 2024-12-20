using CEGES_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
 public class EntrepriseFormVM
    {
        public Entreprise Entreprise { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'entreprise est requis.")]
        public string Nom { get; set; }

        public List<string> SelectAnalystes { get; set; }
    }
}
