
using System.Collections.Generic;
using CEGES_Models;
using CEGES_MVC.Models;

namespace CEGES_Models.ViewModels

{
    public class ListePeriodesVM
    {
        public Dictionary<int, List<Periode>> Periodes { get; set; }
        public Entreprise Entreprise { get; set; }
    }
}
