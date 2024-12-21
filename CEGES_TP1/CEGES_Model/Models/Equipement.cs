
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models
{
    public abstract class Equipement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'équipement est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom de l'équipement ne peut pas dépasser 100 caractères.")]
        public string NomEquipement { get; set; }

        [Required(ErrorMessage = "La mesure de l'équipement est obligatoire.")]
        public double Mesure { get; set; }

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La période est obligatoire.")]
        public int Periode { get; set; }

        [ForeignKey("Groupe")]
        public int GroupeId { get; set; }

       // [ValidateNever]
        public Groupe Groupe { get; set; }
    }
}
