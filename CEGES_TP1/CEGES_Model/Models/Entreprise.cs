using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CEGES_MVC.Models
{
    public class Entreprise
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public ICollection<Groupe>groupes { get; set; }
        public ICollection<EmissionMensuelle> emissionMensuelles { get; set; }
    }

    
   
}
