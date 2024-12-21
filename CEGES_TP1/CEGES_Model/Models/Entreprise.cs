
using CEGES_Models;
using System.ComponentModel.DataAnnotations;

namespace CEGES_Models
{
    public class Entreprise
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'entreprise est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom de l'entreprise ne peut pas dépasser 100 caractères.")]
        public string NomEntreprise { get; set; }

        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string? NoTel { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public string? Courriel { get; set; }

       // [ValidateNever]
        public IList<Groupe> Groupes { get; set; } = new List<Groupe>();
    }
}
