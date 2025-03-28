using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Categorie
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategorie { get; set; }

        [Required(ErrorMessage = "Le type est obligatoire.")]
        [StringLength(50, ErrorMessage = "Ne peut pas dépasser 50 caractères.")]
        public required string TypeCategorie { get; set; }

        [Required(ErrorMessage = "La description est obligatoire.")]
        [StringLength(250, ErrorMessage = "Ne peut pas dépasser 250 caractères.")]
        public required string DescriptionCategorie { get; set; }
    }
}