using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Permission
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
        public int IdPermission { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Ne peut pas dépasser 50 caractères.")]
        public required string IntitulePermission { get; set; }

        [Required(ErrorMessage = "La description est obligatoire.")]
        [StringLength(250, ErrorMessage = "Ne peut pas dépasser 250 caractères.")]
        public required string DescriptionPermission { get; set; }
    }
}