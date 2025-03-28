using System.ComponentModel.DataAnnotations; // Ajout de la directive pour les attributs de validation
using System.ComponentModel.DataAnnotations.Schema; // Ajout de la directive pour les annotations de base de données

namespace MonApplication.Models
{
    public class Contenir
    {   
        [Key] // Clé primaire
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduit { get; set; }
        public int IdCommande { get; set; }
        public DateTime DateCommande { get; set; }
    }
}