using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class TVA
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
        public int IdTVA { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [Range(0, 99, ErrorMessage = "Doit être compris entre 0 et 99.")]
        public required string NomTVA { get; set; }

        [Required(ErrorMessage = "La TVA est obligatoire.")]
        [Range(0.01, 100.00, ErrorMessage = "Doit être compris entre 0.01 et 100.00.")]
        public required int TauxTVA { get; set; }
    }
}