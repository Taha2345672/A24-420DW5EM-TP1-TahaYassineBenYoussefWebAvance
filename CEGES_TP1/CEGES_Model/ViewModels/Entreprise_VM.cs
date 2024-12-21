using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
    public class Entreprise_VM
    {
        public Entreprise Entreprise { get; set; }

        public Entreprise_VM()
        {
            Entreprise = new Entreprise();
        }
        public int NombreGroupes {  get; set; }
        public int NombreEquipement { get; set; }
        public int NombrePeriodesMesurees { get; set; }
        public int nom { get; set; }

    
    }
}


