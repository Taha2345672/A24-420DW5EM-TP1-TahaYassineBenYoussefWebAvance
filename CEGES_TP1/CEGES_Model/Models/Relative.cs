using CEGES_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.Models
{
    public class Relative : Equipement
    {

        public int Id { get; set; }
        public double EmissionIntensiteZero { get; set; }
        public double EmissionIntensiteMax { get; set; }
    }
}