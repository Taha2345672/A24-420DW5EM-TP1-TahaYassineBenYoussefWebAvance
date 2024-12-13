using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_MVC.Models
{
    public class Lineaire : Equipement
    {

        public int id { get; set; }
        public string UniteMesure { get; set; }
        public double FacteurConversion { get; set; }
    }
}
