using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CEGES_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Entreprises_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEquipement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UniteMesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacteurConversion = table.Column<double>(type: "float", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipements_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periodes_Entreprises_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Periodes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmissionMensuelles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    TotalEntreprise = table.Column<double>(type: "float", nullable: false),
                    EquipementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionMensuelles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmissionMensuelles_Equipements_EquipementId",
                        column: x => x.EquipementId,
                        principalTable: "Equipements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipementId = table.Column<int>(type: "int", nullable: false),
                    PeriodeId = table.Column<int>(type: "int", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesures_Equipements_EquipementId",
                        column: x => x.EquipementId,
                        principalTable: "Equipements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Periodes_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "Periodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Entreprises",
                columns: new[] { "Id", "EntrepriseId", "Nom" },
                values: new object[,]
                {
                    { 1, 0, "Desjardins" },
                    { 2, 0, "Ford" },
                    { 3, 0, "Restaurant Domino Longueuil" }
                });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "Id", "EntrepriseId", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "Finance" },
                    { 2, 2, "Manufacturing" },
                    { 3, 3, "Delivery" },
                    { 4, 3, "Kitchen" }
                });

            migrationBuilder.InsertData(
                table: "Periodes",
                columns: new[] { "Id", "Debut", "EntrepriseId", "Fin", "GroupeId", "Nom" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Période 1" },
                    { 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Période 2" },
                    { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Période 1" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "GroupeId", "TypeEquipement" },
                values: new object[,]
                {
                    { 1, "Equipement", 1, "Computer" },
                    { 2, "Equipement", 2, "Truck" },
                    { 3, "Equipement", 4, "Oven" }
                });

            migrationBuilder.InsertData(
                table: "EmissionMensuelles",
                columns: new[] { "Id", "Annee", "EquipementId", "Mois", "TotalEntreprise" },
                values: new object[,]
                {
                    { 1, 2022, 1, "Janvier", 0.0 },
                    { 2, 2022, 2, "Février", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmissionMensuelles_EquipementId",
                table: "EmissionMensuelles",
                column: "EquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_GroupeId",
                table: "Equipements",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EntrepriseId",
                table: "Groupes",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_EquipementId",
                table: "Mesures",
                column: "EquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_PeriodeId",
                table: "Mesures",
                column: "PeriodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodes_EntrepriseId",
                table: "Periodes",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodes_GroupeId",
                table: "Periodes",
                column: "GroupeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmissionMensuelles");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Entreprises");
        }
    }
}
