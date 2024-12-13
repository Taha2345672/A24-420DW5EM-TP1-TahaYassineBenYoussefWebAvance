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

            modelBuilder.Entity("CEGES_MVC.Models.EmissionMensuelle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<int?>("Entrepriseid")
                        .HasColumnType("int");

                    b.Property<string>("Mois")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalEntreprise")
                        .HasColumnType("float");

                    b.Property<int>("equipementid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Entrepriseid");

                    b.HasIndex("equipementid");

                    b.ToTable("EmissionMensuelles");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Entreprise", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("TypeEquipement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupesid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("groupesid");

                    b.ToTable("Equipements");

                    b.HasDiscriminator().HasValue("Equipement");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Entrepriseid")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreGroupe")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Entrepriseid");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Lineaire", b =>
                {
                    b.HasBaseType("CEGES_MVC.Models.Equipement");

                    b.Property<double>("FacteurConversion")
                        .HasColumnType("float");

                    b.Property<string>("UniteMesure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Lineaire");
                });

            modelBuilder.Entity("CEGES_Models.Models.Constante", b =>
                {
                    b.HasBaseType("CEGES_MVC.Models.Equipement");

                    b.Property<double>("Quantite")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Constante");
                });

            modelBuilder.Entity("CEGES_MVC.Models.EmissionMensuelle", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Entreprise", null)
                        .WithMany("emissionMensuelles")
                        .HasForeignKey("Entrepriseid");

                    b.HasOne("CEGES_MVC.Models.Equipement", "equipement")
                        .WithMany("EmissionsMensuelles")
                        .HasForeignKey("equipementid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipement");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Groupe", "groupes")
                        .WithMany("Equipements")
                        .HasForeignKey("groupesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("groupes");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.HasOne("CEGES_MVC.Models.Entreprise", null)
                        .WithMany("groupes")
                        .HasForeignKey("Entrepriseid");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Entreprise", b =>
                {
                    b.Navigation("emissionMensuelles");

                    b.Navigation("groupes");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Equipement", b =>
                {
                    b.Navigation("EmissionsMensuelles");
                });

            modelBuilder.Entity("CEGES_MVC.Models.Groupe", b =>
                {
                    b.Navigation("Equipements");
                });
#pragma warning restore 612, 618
        }
    }
}
