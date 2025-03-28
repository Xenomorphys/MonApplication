using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Ajouter
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPanier { get; set; }
        public int IdProduit { get; set; }
        
        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range(0, 9999, ErrorMessage = "Doit être compris entre 0 et 9999.")]
        public required int QuantiteProduit { get; set; }
    }
}