using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CEGES_MVC.Models;
using CEGES_Models.Models;
using CEGES_Models;





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

        public DbSet<Mesure> Mesures { get; set; }
        public DbSet<Periode> Periodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configuration des relations
            modelBuilder.Entity<Mesure>()
                .HasOne(m => m.Periode)
                .WithMany(p => p.Mesures)
                .HasForeignKey(m => m.PeriodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipement>()
                .HasOne(e => e.Groupes)
                .WithMany(g => g.Equipements)
                .HasForeignKey(e => e.GroupeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Groupe>()
                .HasOne(g => g.Entreprise)
                .WithMany(e => e.Groupes)
                .HasForeignKey(g => g.EntrepriseId)
                .OnDelete(DeleteBehavior.Restrict);


            // Entreprises
            modelBuilder.Entity<Entreprise>().HasData(
                new Entreprise { Id = 1, Nom = "Desjardins" },
                new Entreprise { Id = 2, Nom = "Ford" },
                new Entreprise { Id = 3, Nom = "Restaurant Domino Longueuil" }
            );

            // Groupes
            modelBuilder.Entity<Groupe>().HasData(
                new Groupe { Id = 1, Nom = "Finance", EntrepriseId = 1 },
                new Groupe { Id = 2, Nom = "Manufacturing", EntrepriseId = 2 },
                new Groupe { Id = 3, Nom = "Delivery", EntrepriseId = 3 },
                new Groupe { Id = 4, Nom = "Kitchen", EntrepriseId = 3 }
            );


            modelBuilder.Entity<Periode>().HasData(
            new Periode { Id = 1, Nom = "Période 1", Debut = new DateTime(2022, 1, 1), Fin = new DateTime(2022, 1, 31), EntrepriseId = 1 },
           new Periode { Id = 2, Nom = "Période 2", Debut = new DateTime(2022, 2, 1), Fin = new DateTime(2022, 2, 28), EntrepriseId = 1 },
          new Periode { Id = 3, Nom = "Période 1", Debut = new DateTime(2022, 1, 1), Fin = new DateTime(2022, 1, 31), EntrepriseId = 2 }
);
            // Équipements
            modelBuilder.Entity<Equipement>().HasData(
                new Equipement { Id = 1, TypeEquipement = "Computer", GroupeId = 1 },
                new Equipement { Id = 2, TypeEquipement = "Truck", GroupeId = 2 },
                new Equipement { Id = 3, TypeEquipement = "Oven", GroupeId = 4 }
            );

            // Émissions mensuelles (périodes)
            modelBuilder.Entity<EmissionMensuelle>().HasData(
                new EmissionMensuelle { Id = 1, Mois = "Janvier", Annee = 2022, EquipementId = 1 },
                new EmissionMensuelle { Id = 2, Mois = "Février", Annee = 2022, EquipementId = 2 }
            );
        }

    }
}
    



