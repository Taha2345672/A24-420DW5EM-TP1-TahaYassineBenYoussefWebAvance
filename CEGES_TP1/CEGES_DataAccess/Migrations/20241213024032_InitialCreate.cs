using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreGroupe = table.Column<int>(type: "int", nullable: false),
                    Entrepriseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Groupes_Entreprises_Entrepriseid",
                        column: x => x.Entrepriseid,
                        principalTable: "Entreprises",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEquipement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groupesid = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UniteMesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacteurConversion = table.Column<double>(type: "float", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipements_Groupes_groupesid",
                        column: x => x.groupesid,
                        principalTable: "Groupes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmissionMensuelles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    TotalEntreprise = table.Column<double>(type: "float", nullable: false),
                    equipementid = table.Column<int>(type: "int", nullable: false),
                    Entrepriseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionMensuelles", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmissionMensuelles_Entreprises_Entrepriseid",
                        column: x => x.Entrepriseid,
                        principalTable: "Entreprises",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EmissionMensuelles_Equipements_equipementid",
                        column: x => x.equipementid,
                        principalTable: "Equipements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmissionMensuelles_Entrepriseid",
                table: "EmissionMensuelles",
                column: "Entrepriseid");

            migrationBuilder.CreateIndex(
                name: "IX_EmissionMensuelles_equipementid",
                table: "EmissionMensuelles",
                column: "equipementid");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_groupesid",
                table: "Equipements",
                column: "groupesid");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_Entrepriseid",
                table: "Groupes",
                column: "Entrepriseid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmissionMensuelles");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Entreprises");
        }
    }
}
