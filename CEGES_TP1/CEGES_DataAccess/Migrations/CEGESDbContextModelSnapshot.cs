﻿// <auto-generated />
using System;
using CEGES_DataAccess.data;
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

            modelBuilder.Entity("CEGES_Core.Mesure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipementId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valeur")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EquipementId");

                    b.HasIndex("PeriodeId");

                    b.ToTable("Mesures");
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Debut")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.HasIndex("GroupeId");

                    b.ToTable("Periodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Debut = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntrepriseId = 1,
                            Fin = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Période 1"
                        },
                        new
                        {
                            Id = 2,
                            Debut = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntrepriseId = 1,
                            Fin = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Période 2"
                        },
                        new
                        {
                            Id = 3,
                            Debut = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntrepriseId = 2,
                            Fin = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Période 1"
                        });
                });

            modelBuilder.Entity("CEGES_MVC.Models.EmissionMensuelle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<int>("EquipementId")
                        .HasColumnType("int");

                    b.Property<string>("Mois")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalEntreprise")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipementId");

                    b.ToTable("EmissionMensuelles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Annee = 2022,
                            EquipementId = 1,
                            Mois = "Janvier",
                            TotalEntreprise = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Annee = 2022,
                            EquipementId = 2,
                            Mois = "Février",
                            TotalEntreprise = 0.0
                        });
                });

            modelBuilder.Entity("CEGES_MVC.Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entreprises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntrepriseId = 0,
                            Nom = "Desjardins"
                        },
                        new
                        {
                            Id = 2,
                            EntrepriseId = 0,
                            Nom = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            EntrepriseId = 0,
                            Nom = "Restaurant Domino Longueuil"
                        });
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeEquipement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Equipements");

                    b.HasDiscriminator().HasValue("Equipement");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupeId = 1,
                            TypeEquipement = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            GroupeId = 2,
                            TypeEquipement = "Truck"
                        },
                        new
                        {
                            Id = 3,
                            GroupeId = 4,
                            TypeEquipement = "Oven"
                        });
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreGroupe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Groupes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntrepriseId = 1,
                            Nom = "Finance",
                            NombreGroupe = 0
                        },
                        new
                        {
                            Id = 2,
                            EntrepriseId = 2,
                            Nom = "Manufacturing",
                            NombreGroupe = 0
                        },
                        new
                        {
                            Id = 3,
                            EntrepriseId = 3,
                            Nom = "Delivery",
                            NombreGroupe = 0
                        },
                        new
                        {
                            Id = 4,
                            EntrepriseId = 3,
                            Nom = "Kitchen",
                            NombreGroupe = 0
                        });
                });

            modelBuilder.Entity("CEGES_MVC.Models.Lineaire", b =>
                {
                    b.HasBaseType("CEGES_MVC.Models.Equipement");

                    b.Property<double>("FacteurConversion")
                        .HasColumnType("float");

                    b.Property<string>("UniteMesure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Lineaire");
                });

            modelBuilder.Entity("CEGES_Models.Models.Constante", b =>
                {
                    b.HasBaseType("CEGES_MVC.Models.Equipement");

                    b.Property<double>("Quantite")
                        .HasColumnType("float");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.ToTable("Equipements", t =>
                        {
                            t.Property("id")
                                .HasColumnName("Constante_id");
                        });

                    b.HasDiscriminator().HasValue("Constante");
                });

            modelBuilder.Entity("CEGES_Core.Mesure", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Equipement", "Equipement")
                        .WithMany()
                        .HasForeignKey("EquipementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEGES_Core.Periode", "Periode")
                        .WithMany("Mesures")
                        .HasForeignKey("PeriodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipement");

                    b.Navigation("Periode");
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Entreprise", "Entreprise")
                        .WithMany("Periodes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEGES_MVC.Models.Groupe", null)
                        .WithMany("Periodes")
                        .HasForeignKey("GroupeId");

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("CEGES_MVC.Models.EmissionMensuelle", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Equipement", "equipement")
                        .WithMany("EmissionsMensuelles")
                        .HasForeignKey("EquipementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipement");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Groupe", "groupes")
                        .WithMany("Equipements")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("groupes");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Entreprise", null)
                        .WithMany("Groupes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.Navigation("Mesures");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Entreprise", b =>
                {
                    b.Navigation("Groupes");

                    b.Navigation("Periodes");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.Navigation("EmissionsMensuelles");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.Navigation("Equipements");

                    b.Navigation("Periodes");
                });
#pragma warning restore 612, 618
        }
    }
}
