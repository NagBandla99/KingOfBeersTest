using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NB.KingOfBeers.Database.Migrations
{
    /// <inheritdoc />
    public partial class BreweryBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreweryBeer",
                columns: table => new
                {
                    BreweryBeerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreweryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreweryBeer", x => x.BreweryBeerId);
                    table.ForeignKey(
                        name: "FK_BreweryBeer_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreweryBeer_Brewery_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Brewery",
                        principalColumn: "BreweryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreweryBeer_BeerId",
                table: "BreweryBeer",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_BreweryBeer_BreweryId",
                table: "BreweryBeer",
                column: "BreweryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreweryBeer");
        }
    }
}
