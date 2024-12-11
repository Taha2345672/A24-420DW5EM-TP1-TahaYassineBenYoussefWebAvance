using CEGES_MVC.Areas.Configuration.Controllers;

namespace CEGES_MVC.Models
{
    public class EmissionMensuelle
    {
        public string Mois { get; set; }
        public int Annee { get; set; }
        public double TotalEntreprise { get; set; }
        public Equipement equipement { get; set; }

    }
}
