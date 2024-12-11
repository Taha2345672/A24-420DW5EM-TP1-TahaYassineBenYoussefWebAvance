﻿using System.Collections.Generic;

namespace CEGES_MVC.Models
{
    public class Groupe
    {
        public string Nom { get; set; }
        public int NombreGroupe { get; set; }
        public ICollection<Equipement> Equipements { get; set; }
    }
}
