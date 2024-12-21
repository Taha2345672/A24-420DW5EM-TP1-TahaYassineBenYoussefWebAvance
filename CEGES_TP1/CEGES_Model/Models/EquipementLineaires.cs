using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models
{
    public class EquipementLineaires : Equipement
    {
        [Required(ErrorMessage = "L'unité de mesure est obligatoire.")]
        [StringLength(50, ErrorMessage = "L'unité de mesure ne peut pas dépasser 50 caractères.")]
        public string UniteMesure { get; set; }

        [Required(ErrorMessage = "Le facteur de conversion est obligatoire.")]
        [Range(0, int.MaxValue, ErrorMessage = "Le facteur de conversion doit être un nombre positif.")]
        public int FacteurConversion { get; set; }
    }
}
