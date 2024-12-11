﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CEGES_MVC.Models
{
    public class Equipement
    {
        public string TypeEquipement { get; set; }
        public Groupe groupes { get; set; } 
        public ICollection<EmissionMensuelle> EmissionsMensuelles { get; set; }
    }

}
