using Microsoft.EntityFrameworkCore;
using CEGES_Models;

namespace CEGES_DataAccess
{
    public class CEGESDbContext : DbContext
    {
        public CEGESDbContext(DbContextOptions<CEGESDbContext> options) : base(options)
        {

        }

        public DbSet<Entreprise>? Entreprises { get; set; }
        public DbSet<Groupe>? Groupes { get; set; }
        public DbSet<EquipementConstantes>? EquipementConstantes { get; set; }
        public DbSet<EquipementLineaires>? EquipementLineaires { get; set; }
        public DbSet<EquipementRelatives>? EquipementRelatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entreprise>().ToTable("Entreprises");
            modelBuilder.Entity<Groupe>().ToTable("Groupes");
            modelBuilder.Entity<Equipement>().ToTable("Equipements");

            // Générer des données de départ
            modelBuilder.GenerateData();
        }
    }
}