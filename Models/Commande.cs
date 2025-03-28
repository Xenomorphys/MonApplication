using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Commande
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCommande { get; set; }
        public int IdPanier { get; set; }
        public int IdUtilisateur { get; set; }
        
        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range(0, 99999999, ErrorMessage = "Doit être compris entre 0 et 99999999.")]
        public int NumeroCommande { get; set; }
    }
}