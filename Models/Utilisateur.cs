using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Utilisateur
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
        public int IdUtilisateur { get; set; }
        
        [Required(ErrorMessage = "Le Role est obligatoire.")] // Champ obligatoire
        public required int IdRole { get; set; }
        public Role? Role { get; set; }

        [Required(ErrorMessage = "Le Localite est obligatoire.")] // Champ obligatoire
        public required int IdLocalite { get; set; }
        public Localite? Localite { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")] // Champ obligatoire
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public required string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public required string Prenom { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(255, ErrorMessage = "L'adresse ne peut pas dépasser 255 caractères.")]
        public required string Adresse { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")] // Validation de l'email (format)
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Le mot de passe doit contenir au moins une lettre, un chiffre et un caractère spécial.")] 
            // Validation du mot de passe avec caractères spéciaux. {8,} signifie que le mot de passe doit contenir au moins 8 caractères.
        public required string MotDePasse { get; set; }
    }
}