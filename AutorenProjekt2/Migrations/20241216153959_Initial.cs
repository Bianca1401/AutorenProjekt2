using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutorenProjekt2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buchtitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klappentext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Erscheinungsdatum = table.Column<DateOnly>(type: "date", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bewertung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezension_Buch_BuchId",
                        column: x => x.BuchId,
                        principalTable: "Buch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezension_BuchId",
                table: "Rezension",
                column: "BuchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezension");

            migrationBuilder.DropTable(
                name: "Buch");
        }
    }
}
