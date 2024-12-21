
using CEGES_Models;
using System.Collections.Generic;

namespace CEGES_MVC.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; } // Relation unique avec Entreprise

        public ICollection<Periode> Periodes { get; set; } = new List<Periode>();
        public ICollection<Equipement> Equipements { get; set; } = new List<Equipement>();

        // Calcul dynamique des nombres
        public int NombreEquipements => Equipements?.Count ?? 0;
        public int NombrePeriodes => Periodes?.Count ?? 0;
    }

}

