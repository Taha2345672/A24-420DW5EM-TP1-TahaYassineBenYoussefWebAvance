using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CEGES_MVC.Models;




namespace CEGES_DataAccess.data
{
    public class CEGESDbContext : IdentityDbContext<IdentityUser>
    {
        public CEGESDbContext(DbContextOptions<CEGESDbContext> options) : base(options)
        {
        }

        public DbSet<Entreprise> Entreprises { get; set; }  
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Constante> Constants { get; set; }
        public DbSet<Lineaire> Lineaires { get; set; }
        public DbSet<EmissionMensuelle> EmissionMensuelles { get; set; }

        // Cette méthode permet d'ajouter des données par défaut dans la base de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Appeler la méthode de base

            // Ajouter des données de seed pour l'entité 'Entreprise'
            modelBuilder.Entity<Entreprise>().HasData(
                new Entreprise { Id =1, Nom = "Entreprise A" },
                new Entreprise { Id = 2, Nom = "Entreprise B" }
            );

            // Ajouter des données de seed pour l'entité 'Groupe'
            modelBuilder.Entity<Groupe>().HasData(
                new Groupe { Id = 1, Nom = "Groupe A", NombreGroupe = 1 },
                new Groupe { Id = 2, Nom = "Groupe B", NombreGroupe = 2 }
            );

            // Ajouter des données de seed pour l'entité 'Equipement'
            modelBuilder.Entity<Equipement>().HasData(
                new Equipement { Id = 1, TypeEquipement = "Equipement 1" },
                new Equipement { Id = 2, TypeEquipement= "Equipement 2" }
            );

            // Ajouter des données de seed pour l'entité 'Constante'
            modelBuilder.Entity<Constante>().HasData(
                new Constante { Id = 1, Nom = "Constante A", Quantite = 100 },
                new Constante { Id = 2, Nom = "Constante B", Quantite = 200 }
            );

            // Ajouter des données de seed pour l'entité 'Lineaire'
            modelBuilder.Entity<Lineaire>().HasData(
                new Lineaire { Id = 1, Nom = "Lineaire A", UniteMesure = "m", FacteurConversion = 1.5 },
                new Lineaire { Id = 2, Nom = "Lineaire B", UniteMesure = "cm", FacteurConversion = 0.01 }
            );

            // Ajouter des données de seed pour l'entité 'EmissionMensuelle'
            modelBuilder.Entity<EmissionMensuelle>().HasData(
                new EmissionMensuelle { Id = 1, Mois = "Janvier", Emission = 1000 },
                new EmissionMensuelle { Id = 2, Mois = "Février", Emission = 1200 }
            );
        }
    }
}
    }
}



