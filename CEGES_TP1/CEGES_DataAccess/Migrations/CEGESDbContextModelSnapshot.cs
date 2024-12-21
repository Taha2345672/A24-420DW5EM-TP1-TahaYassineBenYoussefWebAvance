﻿// <auto-generated />
using CEGES_DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CEGES_DataAccess.Migrations
{
    [DbContext(typeof(CEGESDbContext))]
    partial class CEGESDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CEGES_Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Courriel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEntreprise")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Entreprises", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Courriel = "desjardins@desjardins.ca",
                            NoTel = "514-555555",
                            NomEntreprise = "Desjardins"
                        },
                        new
                        {
                            Id = 2,
                            Courriel = "ford@ford.ca",
                            NoTel = "514-555555",
                            NomEntreprise = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            Courriel = "domino@domino.ca",
                            NoTel = "514-555555",
                            NomEntreprise = "Restaurant Domino Longueil"
                        });
                });

            modelBuilder.Entity("CEGES_Models.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<double>("Mesure")
                        .HasColumnType("float");

                    b.Property<string>("NomEquipement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Periode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Equipements", (string)null);

                    b.HasDiscriminator().HasValue("Equipement");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("NomGroupe")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Groupes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntrepriseId = 1,
                            NomGroupe = "GroupeA"
                        },
                        new
                        {
                            Id = 2,
                            EntrepriseId = 1,
                            NomGroupe = "GroupeB"
                        },
                        new
                        {
                            Id = 3,
                            EntrepriseId = 1,
                            NomGroupe = "GroupeC"
                        },
                        new
                        {
                            Id = 4,
                            EntrepriseId = 2,
                            NomGroupe = "GroupeE"
                        },
                        new
                        {
                            Id = 5,
                            EntrepriseId = 2,
                            NomGroupe = "GroupeF"
                        },
                        new
                        {
                            Id = 6,
                            EntrepriseId = 2,
                            NomGroupe = "GroupeG"
                        },
                        new
                        {
                            Id = 7,
                            EntrepriseId = 3,
                            NomGroupe = "GroupeK"
                        },
                        new
                        {
                            Id = 8,
                            EntrepriseId = 3,
                            NomGroupe = "GroupeL"
                        },
                        new
                        {
                            Id = 9,
                            EntrepriseId = 3,
                            NomGroupe = "GroupeM"
                        });
                });

            modelBuilder.Entity("CEGES_Models.EquipementConstantes", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("EquipementConstantes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bureau administratif",
                            GroupeId = 1,
                            Mesure = 0.20000000000000001,
                            NomEquipement = "Bureau administratif",
                            Periode = 30,
                            Quantite = 5
                        },
                        new
                        {
                            Id = 2,
                            Description = "Système d’éclairage",
                            GroupeId = 1,
                            Mesure = 0.5,
                            NomEquipement = "Système d’éclairage",
                            Periode = 30,
                            Quantite = 5
                        });
                });

            modelBuilder.Entity("CEGES_Models.EquipementLineaires", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<int>("FacteurConversion")
                        .HasColumnType("int");

                    b.Property<string>("UniteMesure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("EquipementLineaires");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Description = "Flotte de camions",
                            GroupeId = 2,
                            Mesure = 12534.0,
                            NomEquipement = "Flotte de camions",
                            Periode = 30,
                            FacteurConversion = 0,
                            UniteMesure = "km"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Four à pizza",
                            GroupeId = 2,
                            Mesure = 7942.0,
                            NomEquipement = "Four à pizza",
                            Periode = 30,
                            FacteurConversion = 0,
                            UniteMesure = "pizza"
                        });
                });

            modelBuilder.Entity("CEGES_Models.EquipementRelatives", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<double>("IntesiteMax")
                        .HasColumnType("float");

                    b.Property<double>("IntesiteZero")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("EquipementRelatives");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Description = "Centrale électrique au gaz",
                            GroupeId = 3,
                            Mesure = 72.0,
                            NomEquipement = "Centrale électrique au gaz",
                            Periode = 0,
                            IntesiteMax = 2.4199999999999999,
                            IntesiteZero = 0.070000000000000007
                        },
                        new
                        {
                            Id = 6,
                            Description = "Cuve à électrolyse (aluminerie)",
                            GroupeId = 3,
                            Mesure = 48.0,
                            NomEquipement = "Cuve à électrolyse (aluminerie)",
                            Periode = 0,
                            IntesiteMax = 2.4199999999999999,
                            IntesiteZero = 0.070000000000000007
                        });
                });

            modelBuilder.Entity("CEGES_Models.Equipement", b =>
                {
                    b.HasOne("CEGES_Models.Groupe", "Groupe")
                        .WithMany("Equipements")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.HasOne("CEGES_Models.Entreprise", "Entreprise")
                        .WithMany("Groupes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("CEGES_Models.Entreprise", b =>
                {
                    b.Navigation("Groupes");
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.Navigation("Equipements");
                });
#pragma warning restore 612, 618
        }
    }
}
