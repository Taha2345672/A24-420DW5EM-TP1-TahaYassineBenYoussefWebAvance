using CEGES_Core;
using System.Collections.Generic;

namespace CEGES_MVC.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int NombreGroupe { get; set; }

        public int EntrepriseId { get; set; }

        public ICollection<Periode> Periodes { get; set; } = new List<Periode>();
  


    public ICollection<Equipement> Equipements { get; set; } = new List<Equipement>();

}
}
