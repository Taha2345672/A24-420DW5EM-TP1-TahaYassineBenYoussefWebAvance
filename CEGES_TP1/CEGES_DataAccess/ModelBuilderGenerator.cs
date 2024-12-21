
using CEGES_Models;
using Microsoft.EntityFrameworkCore;
using CEGES_Models;

namespace CEGES_DataAccess
{

    public static class ModelBuilderGenerator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
            #region Données pour Entreprise
            builder.Entity<Entreprise>().HasData(new Entreprise() { Id = 1, NomEntreprise = "Desjardins", NoTel = "514-555555", Courriel = "desjardins@desjardins.ca" });
            builder.Entity<Entreprise>().HasData(new Entreprise() { Id = 2, NomEntreprise = "Ford", NoTel = "514-555555", Courriel = "ford@ford.ca" });
            builder.Entity<Entreprise>().HasData(new Entreprise() { Id = 3, NomEntreprise = "Restaurant Domino Longueil", NoTel = "514-555555", Courriel = "domino@domino.ca" });
            #endregion

            #region Données pour Groupe
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 1, NomGroupe = "GroupeA", EntrepriseId = 1 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 2, NomGroupe = "GroupeB", EntrepriseId = 1 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 3, NomGroupe = "GroupeC", EntrepriseId = 1 });

            builder.Entity<Groupe>().HasData(new Groupe() { Id = 4, NomGroupe = "GroupeE", EntrepriseId = 2 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 5, NomGroupe = "GroupeF", EntrepriseId = 2 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 6, NomGroupe = "GroupeG", EntrepriseId = 2 });

            builder.Entity<Groupe>().HasData(new Groupe() { Id = 7, NomGroupe = "GroupeK", EntrepriseId = 3 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 8, NomGroupe = "GroupeL", EntrepriseId = 3 });
            builder.Entity<Groupe>().HasData(new Groupe() { Id = 9, NomGroupe = "GroupeM", EntrepriseId = 3 });
            #endregion

            #region Données pour Equipements
            builder.Entity<EquipementConstantes>().HasData(new EquipementConstantes() { Id = 1, Description = "Bureau administratif", NomEquipement = "Bureau administratif", Mesure = 0.2, Quantite = 5, GroupeId = 1, Periode = 30 });
            builder.Entity<EquipementConstantes>().HasData(new EquipementConstantes() { Id = 2, Description = "Système d’éclairage", NomEquipement = "Système d’éclairage", Mesure = 0.5, Quantite = 5, GroupeId = 1, Periode = 30 });

            builder.Entity<EquipementLineaires>().HasData(new EquipementLineaires() { Id = 3, Description = "Flotte de camions", NomEquipement = "Flotte de camions", Mesure = 12534, GroupeId = 2, UniteMesure = "km", Periode = 30 });
            builder.Entity<EquipementLineaires>().HasData(new EquipementLineaires() { Id = 4, Description = "Four à pizza", NomEquipement = "Four à pizza", Mesure = 7942, GroupeId = 2, UniteMesure = "pizza", Periode = 30 });

            builder.Entity<EquipementRelatives>().HasData(new EquipementRelatives() { Id = 5, Description = "Centrale électrique au gaz", NomEquipement = "Centrale électrique au gaz", Mesure = 72, IntesiteMax = 2.42, IntesiteZero = 0.07, GroupeId = 3 });
            builder.Entity<EquipementRelatives>().HasData(new EquipementRelatives() { Id = 6, Description = "Cuve à électrolyse (aluminerie)", NomEquipement = "Cuve à électrolyse (aluminerie)", Mesure = 48, IntesiteMax = 2.42, IntesiteZero = 0.07, GroupeId = 3 });
            #endregion
        }
    }
}