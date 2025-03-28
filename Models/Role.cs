using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Role
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Ne peut pas dépasser 50 caractères.")]
        public required string IntituleRole { get; set; }

        [Required(ErrorMessage = "La description est obligatoire.")]
        [StringLength(250, ErrorMessage = "Ne peut pas dépasser 250 caractères.")]
        public required string DescriptionRole { get; set; }
        public ICollection<Utilisateur> Utilisateur { get; set; } = new List<Utilisateur>();
    }
}