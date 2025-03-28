using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Localite
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
        public int IdLocalite { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Ne peut pas dépasser 50 caractères.")]
        public required string NomLocalite { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [Range(1000, 9999, ErrorMessage = "Doit être compris entre 1000 et 9999.")]
        public required int CPLocalite { get; set; }

        public ICollection<Utilisateur> Utilisateur { get; set; } = new List<Utilisateur>();
    }
}