using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Produit
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduit { get; set; }

        [Required(ErrorMessage = "La TVA est obligatoire.")]
        public int IdTVA { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Ne peut pas dépasser 50 caractères.")]
        public required string IntituleProduit { get; set; }

        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range(0, 9999, ErrorMessage = "Doit être compris entre 0 et 9999.")]
        public required int QuantiteProduit { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire.")]
        [Range(0.01, 10000.00, ErrorMessage = "Doit être compris entre 0.01 et 10000.00.")]
        public required decimal PrixProduit { get; set; }
    }
}