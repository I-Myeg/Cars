using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cars.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manafacturers_ManafacturerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Manafacturers");

            migrationBuilder.RenameColumn(
                name: "ManafacturerId",
                table: "Cars",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManafacturerId",
                table: "Cars",
                newName: "IX_Cars_ManufacturerId");

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fabricator = table.Column<string>(type: "text", nullable: true),
                    DateOfFoundation = table.Column<int>(type: "integer", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Workers = table.Column<int>(type: "integer", nullable: false),
                    Branch = table.Column<string>(type: "text", nullable: true),
                    ContactInformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Cars",
                newName: "ManafacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                newName: "IX_Cars_ManafacturerId");

            migrationBuilder.CreateTable(
                name: "Manafacturers",
                columns: table => new
                {
                    ManafacturerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Branch = table.Column<string>(type: "text", nullable: true),
                    ContactInformation = table.Column<string>(type: "text", nullable: true),
                    DateOfFoundation = table.Column<int>(type: "integer", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Fabricator = table.Column<string>(type: "text", nullable: true),
                    Workers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manafacturers", x => x.ManafacturerId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manafacturers_ManafacturerId",
                table: "Cars",
                column: "ManafacturerId",
                principalTable: "Manafacturers",
                principalColumn: "ManafacturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
