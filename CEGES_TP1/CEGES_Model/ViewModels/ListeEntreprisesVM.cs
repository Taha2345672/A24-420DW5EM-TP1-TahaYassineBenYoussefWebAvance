using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
    public class ListeEntreprisesVM
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public int Groupes { get; set; }
        public int Equipements { get; set; }
        public int Periodes { get; set; }
    }
}
