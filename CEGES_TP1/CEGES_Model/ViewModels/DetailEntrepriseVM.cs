﻿using CEGES_Core;
using System.Collections.Generic;
using CEGES_Models;
using CEGES_MVC.Models;
using CEGES_Models.ViewModels;

namespace CEGES_Core.ViewModels
{
    public class DetailEntrepriseVM
    {
        public Entreprise Entreprise { get; set; }
        public List<ListeGroupesVM> Groupes { get; set; }
       // public List<ApplicationUser> Analystes { get; set; }
    }
}
