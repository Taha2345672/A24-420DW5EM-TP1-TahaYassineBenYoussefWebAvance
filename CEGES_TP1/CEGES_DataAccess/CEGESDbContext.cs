using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CEGES_MVC.Models;
using CEGES_Models.Models;




namespace CEGES_DataAccess.data
{
    public class CEGESDbContext : DbContext
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

        //Cette méthode permet d'ajouter des données par défaut dans la base de données
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); // Appeler la méthode de base

        //    Ajouter des données de seed pour l'entité 'Entreprise'
        //    modelBuilder.Entity<Entreprise>().HasData(
        //        new Entreprise { id = 1, Nom = "Entreprise A" },
        //        new Entreprise { id = 2, Nom = "Entreprise B" }
        //    );

        //    Ajouter des données de seed pour l'entité 'Groupe'
        //    modelBuilder.Entity<Groupe>().HasData(
        //        new Groupe { id = 1, Nom = "Groupe A", NombreGroupe = 1 },
        //        new Groupe { id = 2, Nom = "Groupe B", NombreGroupe = 2 }
        //    );

        //    Ajouter des données de seed pour l'entité 'Equipement'
        //    modelBuilder.Entity<Equipement>().HasData(
        //        new Equipement { id = 1, TypeEquipement = "Equipement 1" },
        //        new Equipement { id = 2, TypeEquipement = "Equipement 2" }
        //    );

        //    Ajouter des données de seed pour l'entité 'Constante'
        //    modelBuilder.Entity<Constante>().HasData(
        //        new Constante { id = 1, TypeEquipement = "Constante A", Quantite = 100 },
        //        new Constante { id = 2, TypeEquipement = "Constante B", Quantite = 200 }
        //    );

        //    Ajouter des données de seed pour l'entité 'Lineaire'
        //    modelBuilder.Entity<Lineaire>().HasData(
        //        new Lineaire { id = 1, UniteMesure = "m", FacteurConversion = 1.5 },
        //        new Lineaire { id = 2, UniteMesure = "cm", FacteurConversion = 0.01 }
        //    );

        //    Configuration pour ajouter des données de seed
        //    modelBuilder.Entity<EmissionMensuelle>().HasData(
        //        new EmissionMensuelle { id = 1, Mois = "Janvier", Annee = 2023, TotalEntreprise = 1000 },
        //        new EmissionMensuelle { id = 2, Mois = "Février", Annee = 2023, TotalEntreprise = 1200 })
        //  ;
        //}
    }
}
    



