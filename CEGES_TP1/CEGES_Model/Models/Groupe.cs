using System.Collections.Generic;

namespace CEGES_MVC.Models
{
    public class Groupe
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public int NombreGroupe { get; set; }

        public ICollection<DateTime> Periodes { get; set; } // Par exemple une collection de DateTime


        public ICollection<Equipement> Equipements { get; set; }
    }
}
