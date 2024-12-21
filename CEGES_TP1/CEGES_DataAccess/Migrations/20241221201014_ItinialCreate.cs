using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CEGES_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ItinialCreate : Migration
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
                    NomEntreprise = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NomGroupe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEquipement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mesure = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Periode = table.Column<int>(type: "int", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: true),
                    UniteMesure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FacteurConversion = table.Column<int>(type: "int", nullable: true),
                    IntesiteMax = table.Column<double>(type: "float", nullable: true),
                    IntesiteZero = table.Column<double>(type: "float", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Entreprises",
                columns: new[] { "Id", "Courriel", "NoTel", "NomEntreprise" },
                values: new object[,]
                {
                    { 1, "desjardins@desjardins.ca", "514-555555", "Desjardins" },
                    { 2, "ford@ford.ca", "514-555555", "Ford" },
                    { 3, "domino@domino.ca", "514-555555", "Restaurant Domino Longueil" }
                });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "Id", "EntrepriseId", "NomGroupe" },
                values: new object[,]
                {
                    { 1, 1, "GroupeA" },
                    { 2, 1, "GroupeB" },
                    { 3, 1, "GroupeC" },
                    { 4, 2, "GroupeE" },
                    { 5, 2, "GroupeF" },
                    { 6, 2, "GroupeG" },
                    { 7, 3, "GroupeK" },
                    { 8, 3, "GroupeL" },
                    { 9, 3, "GroupeM" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Description", "Discriminator", "GroupeId", "Mesure", "NomEquipement", "Periode", "Quantite" },
                values: new object[,]
                {
                    { 1, "Bureau administratif", "EquipementConstantes", 1, 0.20000000000000001, "Bureau administratif", 30, 5 },
                    { 2, "Système d’éclairage", "EquipementConstantes", 1, 0.5, "Système d’éclairage", 30, 5 }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Description", "Discriminator", "FacteurConversion", "GroupeId", "Mesure", "NomEquipement", "Periode", "UniteMesure" },
                values: new object[,]
                {
                    { 3, "Flotte de camions", "EquipementLineaires", 0, 2, 12534.0, "Flotte de camions", 30, "km" },
                    { 4, "Four à pizza", "EquipementLineaires", 0, 2, 7942.0, "Four à pizza", 30, "pizza" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Description", "Discriminator", "GroupeId", "IntesiteMax", "IntesiteZero", "Mesure", "NomEquipement", "Periode" },
                values: new object[,]
                {
                    { 5, "Centrale électrique au gaz", "EquipementRelatives", 3, 2.4199999999999999, 0.070000000000000007, 72.0, "Centrale électrique au gaz", 0 },
                    { 6, "Cuve à électrolyse (aluminerie)", "EquipementRelatives", 3, 2.4199999999999999, 0.070000000000000007, 48.0, "Cuve à électrolyse (aluminerie)", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_GroupeId",
                table: "Equipements",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EntrepriseId",
                table: "Groupes",
                column: "EntrepriseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Entreprises");
        }
    }
}
