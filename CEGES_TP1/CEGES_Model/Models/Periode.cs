using CEGES_MVC.Models;
using System;
using System.Collections.Generic;

namespace CEGES_Models
{
    public class Periode
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public List<Mesure> Mesures { get; set; }
        public int EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; }

        

    }

}
       

    

