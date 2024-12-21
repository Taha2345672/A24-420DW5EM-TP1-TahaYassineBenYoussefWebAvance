using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CEGES_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroupeAndPeriode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_EntrepriseId",
                table: "EmissionMensuelles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmissionMensuelles_Equipements_equipementid",
                table: "EmissionMensuelles");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipements_Groupes_groupesid",
                table: "Equipements");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipements",
                table: "Equipements");

            migrationBuilder.DropIndex(
                name: "IX_EmissionMensuelles_EntrepriseId",
                table: "EmissionMensuelles");

            migrationBuilder.DropColumn(
                name: "Periodes",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "EntrepriseId",
                table: "EmissionMensuelles");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Groupes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "groupesid",
                table: "Equipements",
                newName: "GroupeId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipements_groupesid",
                table: "Equipements",
                newName: "IX_Equipements_GroupeId");

            migrationBuilder.RenameColumn(
                name: "equipementid",
                table: "EmissionMensuelles",
                newName: "EquipementId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EmissionMensuelles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_EmissionMensuelles_equipementid",
                table: "EmissionMensuelles",
                newName: "IX_EmissionMensuelles_EquipementId");

            migrationBuilder.AlterColumn<int>(
                name: "EntrepriseId",
                table: "Groupes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Equipements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Equipements",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Constante_id",
                table: "Equipements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId",
                table: "Entreprises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipements",
                table: "Equipements",
                column: "Id");

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
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "EntrepriseId", "Nom", "NombreGroupe" },
                values: new object[,]
                {
                    { 1, 1, "Finance", 0 },
                    { 2, 2, "Manufacturing", 0 },
                    { 3, 3, "Delivery", 0 },
                    { 4, 3, "Kitchen", 0 }
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

            migrationBuilder.AddForeignKey(
                name: "FK_EmissionMensuelles_Equipements_EquipementId",
                table: "EmissionMensuelles",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipements_Groupes_GroupeId",
                table: "Equipements",
                column: "GroupeId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmissionMensuelles_Equipements_EquipementId",
                table: "EmissionMensuelles");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipements_Groupes_GroupeId",
                table: "Equipements");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipements",
                table: "Equipements");

            migrationBuilder.DeleteData(
                table: "EmissionMensuelles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmissionMensuelles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Entreprises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entreprises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entreprises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Equipements");

            migrationBuilder.DropColumn(
                name: "Constante_id",
                table: "Equipements");

            migrationBuilder.DropColumn(
                name: "EntrepriseId",
                table: "Entreprises");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groupes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GroupeId",
                table: "Equipements",
                newName: "groupesid");

            migrationBuilder.RenameIndex(
                name: "IX_Equipements_GroupeId",
                table: "Equipements",
                newName: "IX_Equipements_groupesid");

            migrationBuilder.RenameColumn(
                name: "EquipementId",
                table: "EmissionMensuelles",
                newName: "equipementid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmissionMensuelles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_EmissionMensuelles_EquipementId",
                table: "EmissionMensuelles",
                newName: "IX_EmissionMensuelles_equipementid");

            migrationBuilder.AlterColumn<int>(
                name: "EntrepriseId",
                table: "Groupes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Periodes",
                table: "Groupes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Equipements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId",
                table: "EmissionMensuelles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipements",
                table: "Equipements",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_EmissionMensuelles_EntrepriseId",
                table: "EmissionMensuelles",
                column: "EntrepriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_EntrepriseId",
                table: "EmissionMensuelles",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmissionMensuelles_Equipements_equipementid",
                table: "EmissionMensuelles",
                column: "equipementid",
                principalTable: "Equipements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipements_Groupes_groupesid",
                table: "Equipements",
                column: "groupesid",
                principalTable: "Groupes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id");
        }
    }
}
