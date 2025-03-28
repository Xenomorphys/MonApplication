using Microsoft.EntityFrameworkCore;
using MonApplication.Models;

namespace MonApplication.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Appartenir> Appartenir { get; set; } // Table de jointure entre Produit et Categorie
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<Contenir> Contenir { get; set; } // Table de jointure entre Commande et Produit
        public DbSet<Detenir> Detenir { get; set; } // Table de jointure entre Role et Permission
        public DbSet<Localite> Localite { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<TVA> TVA { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        //public DbSet<PanierProduit> PaniersProduits { get; set; }
        //public DbSet<CommandeProduit> CommandesProduits { get; set; }
        //public DbSet<Paiement> Paiements { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartenir>().HasKey(pp => new { pp.IdCategorie, pp.IdProduit });
            modelBuilder.Entity<Detenir>().HasKey(pp => new { pp.IdPermission, pp.IdRole });
            modelBuilder.Entity<Contenir>().HasKey(cp => new { cp.IdCommande, cp.IdProduit });

            modelBuilder.Entity<Utilisateur>().HasOne(u => u.Role).WithMany(r => r.Utilisateur).HasForeignKey(u => u.IdRole);
            modelBuilder.Entity<Utilisateur>().HasOne(u => u.Localite).WithMany(l => l.Utilisateur).HasForeignKey(u => u.IdLocalite);
        }
    }
}