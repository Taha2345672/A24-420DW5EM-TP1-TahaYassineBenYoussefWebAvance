
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models
{
    public class Groupe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du groupe est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom du groupe ne peut pas dépasser 100 caractères.")]
        public string NomGroupe { get; set; }

        [ForeignKey("Entreprise")]
        public int EntrepriseId { get; set; }

       // [ValidateNever]
        public Entreprise Entreprise { get; set; }

        //[ValidateNever]
        public IList<Equipement> Equipements { get; set; } = new List<Equipement>();
    }
}
