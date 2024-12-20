using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEGES_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_Entrepriseid",
                table: "EmissionMensuelles");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Entreprises_Entrepriseid",
                table: "Groupes");

            migrationBuilder.RenameColumn(
                name: "Entrepriseid",
                table: "Groupes",
                newName: "EntrepriseId");

            migrationBuilder.RenameIndex(
                name: "IX_Groupes_Entrepriseid",
                table: "Groupes",
                newName: "IX_Groupes_EntrepriseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Entreprises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Entrepriseid",
                table: "EmissionMensuelles",
                newName: "EntrepriseId");

            migrationBuilder.RenameIndex(
                name: "IX_EmissionMensuelles_Entrepriseid",
                table: "EmissionMensuelles",
                newName: "IX_EmissionMensuelles_EntrepriseId");

            migrationBuilder.AddColumn<string>(
                name: "Periodes",
                table: "Groupes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_EntrepriseId",
                table: "EmissionMensuelles",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_EntrepriseId",
                table: "EmissionMensuelles");

            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Entreprises_EntrepriseId",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "Periodes",
                table: "Groupes");

            migrationBuilder.RenameColumn(
                name: "EntrepriseId",
                table: "Groupes",
                newName: "Entrepriseid");

            migrationBuilder.RenameIndex(
                name: "IX_Groupes_EntrepriseId",
                table: "Groupes",
                newName: "IX_Groupes_Entrepriseid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Entreprises",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EntrepriseId",
                table: "EmissionMensuelles",
                newName: "Entrepriseid");

            migrationBuilder.RenameIndex(
                name: "IX_EmissionMensuelles_EntrepriseId",
                table: "EmissionMensuelles",
                newName: "IX_EmissionMensuelles_Entrepriseid");

            migrationBuilder.AddForeignKey(
                name: "FK_EmissionMensuelles_Entreprises_Entrepriseid",
                table: "EmissionMensuelles",
                column: "Entrepriseid",
                principalTable: "Entreprises",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Entreprises_Entrepriseid",
                table: "Groupes",
                column: "Entrepriseid",
                principalTable: "Entreprises",
                principalColumn: "id");
        }
    }
}
