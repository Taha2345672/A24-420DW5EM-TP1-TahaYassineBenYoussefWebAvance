using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models
{
    public class EquipementRelatives : Equipement
    {
        [Required(ErrorMessage = "L'intensité maximale est obligatoire.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "L'intensité maximale doit être un nombre positif.")]
        public double IntesiteMax { get; set; }

        [Required(ErrorMessage = "L'intensité zéro est obligatoire.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "L'intensité zéro doit être un nombre positif.")]
        public double IntesiteZero { get; set; }
    }
}
