using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NB.KingOfBeers.Database.Migrations
{
    /// <inheritdoc />
    public partial class BarBeers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarBeer",
                columns: table => new
                {
                    BarBeerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarId = table.Column<int>(type: "INTEGER", nullable: false),
                    BreweryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarBeer", x => x.BarBeerId);
                    table.ForeignKey(
                        name: "FK_BarBeer_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarBeer_BeerId",
                table: "BarBeer",
                column: "BeerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarBeer");
        }
    }
}
