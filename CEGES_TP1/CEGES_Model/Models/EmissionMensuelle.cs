using System.Collections.Generic;

namespace CEGES_MVC.Models
{
    public class EmissionMensuelle
    {

        public int Id { get; set; }
        public string Mois { get; set; }
        public int Annee { get; set; }
        public double TotalEntreprise { get; set; }
        public Equipement equipement { get; set; }
        public int EquipementId { get; set; }
    }
}
